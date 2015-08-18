using System;

namespace TMD.Models.DomainModels
{
    public class ProductImage
    {
        public Guid ImageId { get; set; }
        public long ProductId { get; set; }
        public byte[] ImageData { get; set; }
        public bool IsDefaultImage { get; set; }
        public string ContentType { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
