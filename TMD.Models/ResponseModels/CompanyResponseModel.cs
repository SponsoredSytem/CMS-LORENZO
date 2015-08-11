using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class CompanyResponseModel
    {
        public Company Company{get; set; }
        public IEnumerable<City> Cities{ get; set; }
        public IEnumerable<Municipal> Municipals { get; set; }
        public IEnumerable<Source> Sources { get; set; }
        public IEnumerable<CompanyContact> CompanyContacts { get; set; }
    }
}
