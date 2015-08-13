using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class MunicipalViewModel
    {
        public List<City> CityList { get; set; }

        public Municipal Municipal { get; set; }

        public long CityId { get; set; }
    }
}