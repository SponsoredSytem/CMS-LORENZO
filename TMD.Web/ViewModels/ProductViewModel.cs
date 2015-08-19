using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<ProductCategoryModel>();
        }
        public ProductModel ProductModel { get; set; }
        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; }
        public IEnumerable<ColorModel> Colors { get; set; }
        public IEnumerable<CurrencyModel> Currencies { get; set; }
        public IEnumerable<SizeModel> Sizes { get; set; }
        [Display(Name = "Upload Product Image")]
        public HttpPostedFileBase ProductDefaultImage { get; set; }
    }
}