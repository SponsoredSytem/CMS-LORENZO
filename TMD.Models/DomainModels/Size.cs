using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeTitle { get; set; }
        public string SizeValue { get; set; }
        public string SizeDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
