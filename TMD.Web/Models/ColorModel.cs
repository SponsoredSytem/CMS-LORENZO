using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class ColorModel
    {
        public int ColorId { get; set; }
        [Display(Name = "Color Title")]
        public string ColorTitle { get; set; }
        [Display(Name = "Color Value")]
        public string ColorValue { get; set; }
        [Display(Name = "Color Description")]
        public string ColorDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}