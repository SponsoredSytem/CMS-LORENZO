using System.Collections.Generic;
using TMD.Web.Models;
using TMD.Web.Models.Common;

namespace TMD.Web.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            Cities=new List<City>();
            Municipals=new List<Municipal>();
            CompanyContacts = new List<CompanyContact>();
        }
        public Company Company { get; set; }
        public List<City> Cities { get; set; }
        public List<Municipal> Municipals { get; set; }
        public List<Source> Sources { get; set; }
        public List<CompanyContact> CompanyContacts { get; set; }
        public List<EmployeesDropdownModel> Employees { get; set; } 
    }
}