using System;
using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Municipal
    {
        public long MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        public string MunicipalDescription { get; set; }
        public Nullable<System.DateTime> RecCreatedDate { get; set; }
        public Nullable<System.DateTime> RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public long CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
