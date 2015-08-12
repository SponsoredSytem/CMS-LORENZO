using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;

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

        //
        // GET: /lookup/Create
        public ActionResult CityCreate(long? id)
        {
            City model = new City();
            if (id != null)
            {
                var city = cityService.GetCity(id.Value);
                if (city != null)
                    model = city.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /ExpenseCategory/Create
        [HttpPost]
        public ActionResult CityCreate(City cityModel)
        {
            try
            {
                if (cityModel.CityId == 0)
                {
                    cityModel.RecCreatedBy = User.Identity.Name;
                    cityModel.RecCreatedDate = DateTime.Now;
                }
                cityModel.RecLastUpdatedBy = User.Identity.Name;
                cityModel.RecLastUpdatedDate = DateTime.Now;
                
                if (cityService.SaveCity(cityModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "City has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("City", "Lookup");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                    bool result = cityService.DeleteCity(cityService.GetCity(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "City has been used in Munnicipal and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }



    }
}