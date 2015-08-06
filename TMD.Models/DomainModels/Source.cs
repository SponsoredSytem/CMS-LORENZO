using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Source
    {
        public long SourceId { get; set; }
        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
