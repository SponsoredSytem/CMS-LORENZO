using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class LookupController : BaseController
    {

        private readonly ICityService cityService;
        private readonly ISourceService sourceService;
        private readonly IMunicipalService municipalService;
        private readonly ICompanyStatusService companyStatusService;
        private readonly ICurrencyService currencyService;
        private readonly IColorService colorService;
        private readonly ISizeService sizeService;

        public LookupController(ICityService cityService, ISourceService sourceService, IMunicipalService municipalService, ICompanyStatusService companyStatusService, ICurrencyService currencyService, IColorService colorService, ISizeService sizeService)
        {
            this.cityService = cityService;
            this.sourceService = sourceService;
            this.municipalService = municipalService;
            this.companyStatusService = companyStatusService;
            this.currencyService = currencyService;
            this.colorService = colorService;
            this.sizeService = sizeService;
        }
        
        #region City
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
        public ActionResult DeleteCity(int id)
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

        #endregion
        
        #region Source
        public ActionResult Sources()
        {
            IEnumerable<Source> sources = sourceService.GetAllSources().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(sources);
        }

        //
        // GET: /lookup/Create
        public ActionResult SourceManage(long? id)
        {
            Source model = new Source();
            if (id != null)
            {
                var Source = sourceService.GetSource(id.Value);
                if (Source != null)
                    model = Source.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /ExpenseCategory/Create
        [HttpPost]
        public ActionResult SourceManage(Source SourceModel)
        {
            try
            {
                if (SourceModel.SourceId == 0)
                {
                    SourceModel.RecCreatedBy = User.Identity.Name;
                    SourceModel.RecCreatedDate = DateTime.Now;
                }
                SourceModel.RecLastUpdatedBy = User.Identity.Name;
                SourceModel.RecLastUpdatedDate = DateTime.Now;

                if (sourceService.SaveSource(SourceModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Source has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Sources", "Lookup");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteSource(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                bool result = sourceService.DeleteSource(sourceService.GetSource(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "Source has been used in Munnicipal and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Currency
        public ActionResult Currency()
        {
            IEnumerable<CurrencyModel> currencies = currencyService.GetAllCurrencies().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(currencies);
        }

        public ActionResult CurrencyManage(int? id)
        {
            var model = new CurrencyModel();
            if (id != null)
            {
                var currency = currencyService.GetCurrency(id.Value);
                if (currency != null)
                    model = currency.CreateFromServerToClient();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CurrencyManage(CurrencyModel model)
        {
            try
            {
                if (model.CurrencyId == 0)
                {
                    model.RecCreatedBy = User.Identity.Name;
                    model.RecCreatedDate = DateTime.Now;
                }
                model.RecLastUpdatedBy = User.Identity.Name;
                model.RecLastUpdatedDate = DateTime.Now;

                if (currencyService.SaveCurrency(model.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Currency has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Currency", "Lookup");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteCurrency(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                bool result = currencyService.DeleteCurrency(currencyService.GetCurrency(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "Currency has been used in Product and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Color
        public ActionResult Color()
        {
            IEnumerable<ColorModel> colors = colorService.GetAllColors().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(colors);
        }

        public ActionResult ColorManage(int? id)
        {
            var model = new ColorModel();
            if (id != null)
            {
                var color = colorService.GetColor(id.Value);
                if (color != null)
                    model = color.CreateFromServerToClient();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ColorManage(ColorModel model)
        {
            try
            {
                if (model.ColorId == 0)
                {
                    model.RecCreatedBy = User.Identity.Name;
                    model.RecCreatedDate = DateTime.Now;
                }
                model.RecLastUpdatedBy = User.Identity.Name;
                model.RecLastUpdatedDate = DateTime.Now;

                if (colorService.SaveColor(model.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Color has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Color", "Lookup");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteColor(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                bool result = colorService.DeleteColor(colorService.GetColor(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "Color has been used in Product and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Size
        public ActionResult Size()
        {
            IEnumerable<SizeModel> sizes = sizeService.GetAllSizes().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(sizes);
        }

        public ActionResult SizeManage(int? id)
        {
            var model = new SizeModel();
            if (id != null)
            {
                var size = sizeService.GetSize(id.Value);
                if (size != null)
                    model = size.CreateFromServerToClient();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SizeManage(SizeModel model)
        {
            try
            {
                if (model.SizeId == 0)
                {
                    model.RecCreatedBy = User.Identity.Name;
                    model.RecCreatedDate = DateTime.Now;
                }
                model.RecLastUpdatedBy = User.Identity.Name;
                model.RecLastUpdatedDate = DateTime.Now;

                if (sizeService.SaveSize(model.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Size has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Size", "Lookup");
            }
            catch (Exception exp)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteSize(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                bool result = sizeService.DeleteSize(sizeService.GetSize(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "Size has been used in Product and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Municipal
        public ActionResult Municipals()
        {
            IEnumerable<Municipal> Municipals = municipalService.GetAllMunicipals().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(Municipals);
        }

        //
        // GET: /lookup/Create
        public ActionResult MunicipalManage(long? id)
        {
            MunicipalViewModel oVM = new MunicipalViewModel();
            oVM.CityList = cityService.GetAllCities().Select(x => x.CreateFromServerToClient()).ToList();
            oVM.Municipal = new Municipal();
            Municipal model = new Municipal();
            if (id != null)
            {
                var Municipal = municipalService.GetMunicipal(id.Value);
                if (Municipal != null)
                    model = Municipal.CreateFromServerToClient();
                oVM.Municipal = model;
            }
            return View(oVM);
        }

        //
        // POST: /ExpenseCategory/Create
        [HttpPost]
        public ActionResult MunicipalManage(MunicipalViewModel MunicipalModel)
        {
            try
            {
                if (MunicipalModel.Municipal.MunicipalId == 0)
                {
                    MunicipalModel.Municipal.RecCreatedBy = User.Identity.Name;
                    MunicipalModel.Municipal.RecCreatedDate = DateTime.Now;
                }
                MunicipalModel.Municipal.RecLastUpdatedBy = User.Identity.Name;
                MunicipalModel.Municipal.RecLastUpdatedDate = DateTime.Now;

                if (municipalService.SaveMunicipal(MunicipalModel.Municipal.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Municipal has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Municipals", "Lookup");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteMunicipal(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
              //  bool result = municipalService.DeleteMunicipal(municipalService.GetMunicipal(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "Municipal has been used in Munnicipal and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Company Statuses
        public ActionResult CompanyStatuses()
        {
            IEnumerable<CompanyStatus> companyStatuses= companyStatusService.GetCompanyStatusesBySortOrder().Select(x => x.CreateFromServerToClient());
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(companyStatuses);
        }


        // GET: /lookup/Create
        public ActionResult CompanyStatusManage(long? id)
        {
            CompanyStatus model = new CompanyStatus();
            if (id != null)
            {
                var CompanyStatus = companyStatusService.GetCompanyStatus(id.Value);
                if (CompanyStatus != null)
                    model = CompanyStatus.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /ExpenseCategory/Create
        [HttpPost]
        public ActionResult CompanyStatusManage(CompanyStatus CompanyStatusModel)
        {
            try
            {
                if (CompanyStatusModel.StatusId == 0)
                {
                    CompanyStatusModel.RecCreatedBy = User.Identity.Name;
                    CompanyStatusModel.RecCreatedDate = DateTime.Now;
                }
                CompanyStatusModel.RecLastUpdatedBy = User.Identity.Name;
                CompanyStatusModel.RecLastUpdatedDate = DateTime.Now;

                if (companyStatusService.SaveCompanyStatus(CompanyStatusModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "CompanyStatus has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("CompanyStatuses", "Lookup");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteCompanyStatus(int id)
        {
            string actionMessage;
            try
            {
                actionMessage = "Deleted";
                bool result = companyStatusService.DeleteCompanyStatus(companyStatusService.GetCompanyStatus(id));
            }
            catch (Exception exp)
            {
                //WebBase.Helper.LogError.Log(exp);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Dictionary<string, object> error = new Dictionary<string, object> { { "ErrorMessage", "CompanyStatus has been used in Munnicipal and cannot be deleted" } };
                return Json(error);
            }
            return Json(new { response = actionMessage, status = (int)HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

#endregion
    }
}