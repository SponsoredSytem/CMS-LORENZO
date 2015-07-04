﻿using System;
using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class InventoryController : BaseController
    {
        private readonly IInventoryItemService inventoryItemService;
        private readonly IProductService productService;
        private readonly IVendorService vendorService;


        public InventoryController(IInventoryItemService inventoryItemService,IProductService productService,IVendorService vendorService)
        {
            this.inventoryItemService = inventoryItemService;
            this.productService = productService;
            this.vendorService = vendorService;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create(long? id)
        {
            InventoryItemViewModel inventoryItemViewModel=new InventoryItemViewModel();
            if (id != null)
            {
                var inventoryItem = inventoryItemService.GetInventoryItem((long)id);
                if (inventoryItem != null)
                    inventoryItemViewModel.InventoryItem = inventoryItem.CreateFromServerToClient();
            }
            var vendors = vendorService.GetAllVendors().ToList();
            if (vendors.Any())
                inventoryItemViewModel.Vendors = vendors.Select(x => x.CreateFromServerToClient());
            return View(inventoryItemViewModel);
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(InventoryItemViewModel inventoryItemViewModel)
        {
            try
            {
                if (inventoryItemViewModel.InventoryItem.ItemId == 0)
                {
                    inventoryItemViewModel.InventoryItem.RecCreatedBy = User.Identity.Name;
                    inventoryItemViewModel.InventoryItem.RecCreatedDate = DateTime.Now;
                }
                inventoryItemViewModel.InventoryItem.RecLastUpdatedBy = User.Identity.Name;
                inventoryItemViewModel.InventoryItem.RecLastUpdatedDate = DateTime.Now;

                //Minimum sale price should not be less than purchase price
                if (inventoryItemViewModel.InventoryItem.MinSalePriceAllowed <
                    inventoryItemViewModel.InventoryItem.PurchasePrice)
                    inventoryItemViewModel.InventoryItem.MinSalePriceAllowed =
                        inventoryItemViewModel.InventoryItem.SalePrice;
                if (inventoryItemService.AddInventoryItem(inventoryItemViewModel.InventoryItem.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Inventory has been saved successfully.", IsSaved = true };
                }


                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
