using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorTitle { get; set; }
        public string ColorValue { get; set; }
        public string ColorDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
