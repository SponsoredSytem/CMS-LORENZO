using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            Cities=new List<City>();
            Municipals=new List<Municipal>();
        }
        public Company Company { get; set; }
        public List<City> Cities { get; set; }
        public List<Municipal> Municipals { get; set; }
        public List<Source> Sources { get; set; } 
    }
}