using System;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class ProductModel
    {
        
        public long ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Display(Name = "Vendor Barcode")]
        public string ProductBarCode { get; set; }

        [Required]
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Minimum Sale Price Allowed")]
        public decimal MinSalePriceAllowed { get; set; }

        [Required]
        [Display(Name = "Category")]
        public long CategoryId { get; set; }

        [Required]
        [Display(Name = "V.A.T Rate")]
        [Range(1, 100, ErrorMessage = "Please enter valid value.")]
        public double? VATRate { get; set; }

        [Display(Name = "Vendor")]
        public long VendorId { get; set; }
        public string Comments { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        [Display(Name = "Currency")]
        public int? CurrencyId { get; set; }
        [Display(Name = "Size")]
        public int? SizeId { get; set; }
        [Display(Name = "Color")]
        public int? ColorId { get; set; }
        public string ProductDefaultImageId { get; set; }

        //ADDED BY USMAN
        public string CategoryName { get; set; } //To display on Listview
    }
}