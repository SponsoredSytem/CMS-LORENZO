using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;

namespace TMD.Web.Controllers
{
    public class LookupController : BaseController
    {

        private readonly ICityService cityService;

        public LookupController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        //
        // GET: /Lookup/
        public ActionResult City()
        {
            IEnumerable<City> cities = cityService.GetAllCities().Select(x => x.CreateFromServerToClient());
            return View(cities);
        }
	}
}