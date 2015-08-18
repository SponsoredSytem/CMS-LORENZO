using System.Collections.Generic;
using System.Drawing;
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
    }
}