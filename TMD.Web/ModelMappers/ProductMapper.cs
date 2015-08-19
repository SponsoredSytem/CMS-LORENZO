using System;
using System.Linq;
using TMD.Models.DomainModels;
using TMD.Web.Models;
using TMD.Web.ViewModels.ApiModels;

namespace TMD.Web.ModelMappers
{
    public static class ProductMapper
    {
        public static Product CreateFromClientToServer(this ProductModel source)
        {
            return new Product
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,
                CurrencyId = source.CurrencyId,
                ColorId = source.ColorId,
                SizeId = source.SizeId,
                VATRate = source.VATRate,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static ProductModel CreateFromServerToClient(this Product source)
        {
            var ProductDefaultImageId = source.ProductImages.FirstOrDefault(x => x.IsDefaultImage) != null
                ? Convert.ToString(source.ProductImages.FirstOrDefault(x => x.IsDefaultImage).ImageId)
                : "";
            return new ProductModel
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,

                CurrencyId = source.CurrencyId,
                ColorId = source.ColorId,
                SizeId = source.SizeId,
                VATRate = source.VATRate,

                ColorTitle = source.Color!=null?source.Color.ColorTitle:"",
                SizeTitle = source.Size!=null?source.Size.SizeTitle:"",
                ProductDefaultImageTag = string.IsNullOrEmpty(ProductDefaultImageId)?"": "<img src='/Product/ProductImage?imageId=" + ProductDefaultImageId + "' width='100%'/>",
                ProductDefaultImageId = ProductDefaultImageId,
                CategoryName = source.ProductCategory.Name,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static ProductApiModel CreateApiModelServerToClient(this Product source)
        {
            return new ProductApiModel
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
            };
        }
    }
}