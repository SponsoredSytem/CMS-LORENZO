﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;
        private readonly IProductImageService productImageService;

        public ProductController(IProductService productService,IProductCategoryService productCategoryService, IProductImageService productImageService)
        {
            this.productService = productService;
            this.productCategoryService = productCategoryService;
            this.productImageService = productImageService;
        }

        // GET: Products
        public ActionResult Index()
        {
            ProductSearchRequest searchRequest = Session["PageMetaData"] as ProductSearchRequest;
            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;

            var categories = productCategoryService.GetAllProductCategories().ToList();
            return View(new ProductsListViewModel
            {
                SearchRequest = searchRequest ?? new ProductSearchRequest(),
                ProductCategories = categories.Any()?categories.Select(x=>x.CreateFromServerToClient()):new List<ProductCategoryModel>()
            });
        }
        [HttpPost]
        public ActionResult Index(ProductSearchRequest searchRequest)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel();
            try
            {
                ProductSearchResponse searchResponse = productService.GetProductSearchResponse(searchRequest);

                var resultData = searchResponse.Products.Any()
                    ? searchResponse.Products.Select(x => x.CreateFromServerToClient()).ToList()
                    : new List<ProductModel>();

                viewModel.data = resultData;
                viewModel.recordsTotal = searchResponse.TotalCount;
                viewModel.recordsFiltered = searchResponse.FilteredCount;

                // Keep Search Request in Session
                Session["PageMetaData"] = searchRequest;
                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                TempData["message"] = new MessageViewModel { Message = "There is some problem, please try again.", IsError = true };
                return View(viewModel);
            }
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create(long? id)
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            ProductViewModel productViewModel=new ProductViewModel();
            var responseResult = productService.GetProductResponse(id);

            if (responseResult.ProductCategories.Any())
                productViewModel.ProductCategories = responseResult.ProductCategories.Select(x => x.CreateFromServerToClient());

            productViewModel.Sizes = responseResult.Sizes.Select(x => x.CreateFromServerToClient());
            productViewModel.Colors = responseResult.Colors.Select(x => x.CreateFromServerToClient());
            productViewModel.Currencies = responseResult.Currencies.Select(x => x.CreateFromServerToClient());

            if (responseResult.Product != null)
                productViewModel.ProductModel = responseResult.Product.CreateFromServerToClient();
            
            var lastSavedCategoryID = TempData["LastCategoryId"];
            if (lastSavedCategoryID != null)
            {
                if (productViewModel.ProductModel== null)
                    productViewModel.ProductModel = new ProductModel();
                productViewModel.ProductModel.CategoryId = long.Parse(lastSavedCategoryID.ToString());
            }


            ViewBag.LastSavedId = TempData["LastSavedId"];
            return View(productViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                bool isCreated = false;
                if (productViewModel.ProductModel.ProductId == 0)
                {
                    productViewModel.ProductModel.RecCreatedBy = User.Identity.Name;
                    productViewModel.ProductModel.RecCreatedDate = DateTime.Now;
                    isCreated = true;
                }
                productViewModel.ProductModel.RecLastUpdatedBy = User.Identity.Name;
                productViewModel.ProductModel.RecLastUpdatedDate = DateTime.Now;

                //Minimum sale price should not be less than purchase price
                //if (productViewModel.ProductModel.MinSalePriceAllowed <
                //    productViewModel.ProductModel.PurchasePrice)
                //    productViewModel.ProductModel.MinSalePriceAllowed =
                //        productViewModel.ProductModel.SalePrice;
                var lastSavedId = productService.SaveProduct(productViewModel.ProductModel.CreateFromClientToServer());
                if (lastSavedId > 0)
                {
                    //Save image to Db
                    if (productViewModel.ProductDefaultImage != null)
                    {
                        #region Image Saving

                        try
                        {
                            var tempStream = productViewModel.ProductDefaultImage.InputStream;

                            //File size must be less than 10MBs
                            if (productViewModel.ProductDefaultImage.ContentLength > 0 && productViewModel.ProductDefaultImage.ContentLength < 10000000)
                            {
                                //reisze the image for facebook optimization
                                var resizedImage = Utility.ResizeImage(Image.FromStream(tempStream), Utility.GetImageFormat(productViewModel.ProductDefaultImage.ContentType), Convert.ToInt32(ConfigurationManager.AppSettings["ProductImageWidth"]), Convert.ToInt32(ConfigurationManager.AppSettings["ProductImageHeight"]), true);

                                byte[] bytes = new byte[resizedImage.Length];
                                //copy file content to array
                                resizedImage.Read(bytes, 0, Convert.ToInt32(resizedImage.Length));

                                ProductImage productImage = new ProductImage
                                {
                                    ImageId = productViewModel.ProductModel.ProductDefaultImageId != null ? new Guid(productViewModel.ProductModel.ProductDefaultImageId) : Guid.NewGuid(),
                                    ProductId = lastSavedId,
                                    IsDefaultImage = true,
                                    ImageData = bytes,
                                    ContentType = productViewModel.ProductDefaultImage.ContentType,
                                    CreatedBy = User.Identity.GetUserId(),
                                    CreatedDate = DateTime.Now.Date,
                                    UpdatedBy = User.Identity.GetUserId(),
                                    UpdatedDate = DateTime.Now.Date,
                                };
                                productImageService.AddProductImage(productImage);
                            }

                        }
                        catch (Exception exception)
                        {
                            TempData["message"] = new MessageViewModel { Message = "There is some problem in saving the image, please try again and upload a correct image.", IsError = true };
                            return RedirectToAction("UserActivityAdd");
                        }

                        #endregion
                    }
                    if (isCreated)
                    {
                        //Product Saved
                        TempData["message"] = new MessageViewModel { Message = "Product has been saved successfully.<br/>Last saved product id is " + lastSavedId, IsSaved = true };
                    }
                    else
                    {
                        //Product Updated
                        TempData["message"] = new MessageViewModel { Message = "Product has been updated successfully.<br/>Updated product id is " + lastSavedId, IsUpdated = true };
                    }
                }

                if (Request.Form["save"]!=null)
                    return RedirectToAction("Index");
                if (isCreated)
                {
                    TempData["LastSavedId"] = lastSavedId;
                    
                    TempData["LastCategoryId"] = productViewModel.ProductModel.CategoryId;
                }
                return RedirectToAction("Create");
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        #region User Activity Image
        public ActionResult ProductImage(Guid imageId)
        {
            //pas id to service, and load image data
            var image = productImageService.GetProductImage(imageId);

            //JOHN: Modified UpdatedDate to use Specific string date format.  Different Geo date formats could cause a bad URL Structure depending on seperators
            if (image != null && image.ImageData != null)
            {
                string ext = image.ContentType.Split('/')[1];
                return File(image.ImageData, image.ContentType, "IMG_" + image.ImageId + ((DateTime)image.UpdatedDate).ToString("yyyyMMdd_HHmmss") + "." + ext);
            }
            return File(new byte[] { }, "image/png", "null.png");
        }
        #endregion
    }
}
