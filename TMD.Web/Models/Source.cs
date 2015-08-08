using System;

namespace TMD.Web.Models
{
    public class Source
    {
        public long SourceId { get; set; }
        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}