using System;

namespace TMD.Web.Models
{
    public class Municipal
    {
        public long MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        public string MunicipalDescription { get; set; }
        public DateTime? RecCreatedDate { get; set; }
        public DateTime? RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public long CityId { get; set; }
    }
}