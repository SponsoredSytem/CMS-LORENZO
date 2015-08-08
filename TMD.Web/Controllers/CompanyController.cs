using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(long? id)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
           
                var companyData = companyService.GetCompanyResponse(id);
                companyViewModel.Company = companyData.Company!=null ? companyData.Company.CreateFromServerToClient() : new Company();

            companyViewModel.Cities = companyData.Cities.Select(x => x.CreateFromServerToClient()).ToList();
            companyViewModel.Sources = companyData.Sources.Select(x => x.CreateFromServerToClient()).ToList();
            return View(companyViewModel);
        }
        [HttpPost]
        public ActionResult Create(CompanyViewModel companyViewModel)
        {
            try
            {
                if (companyViewModel.Company.CompanyId > 0)
                {
                    companyViewModel.Company.RecLastUpdatedBy = User.Identity.GetUserId();
                    companyViewModel.Company.RecLastUpdatedDate = DateTime.Now;
                }
                else
                {
                    companyViewModel.Company.RecCreatedBy = User.Identity.GetUserId();
                    companyViewModel.Company.RecCreatedDate = DateTime.Now;
                    companyViewModel.Company.RecLastUpdatedBy = User.Identity.GetUserId();
                    companyViewModel.Company.RecLastUpdatedDate = DateTime.Now;
                }
                companyService.SaveCompany(companyViewModel.Company.CreateFromClientToServer());

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                throw;
            }
            return View();
        }
    }
}