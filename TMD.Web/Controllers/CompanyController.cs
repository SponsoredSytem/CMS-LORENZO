using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.Models.Common;
using TMD.Web.ViewModels;

namespace TMD.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        // GET: Company
        public ActionResult Index()
        {
            var companies = companyService.GetAllCompanies().ToList().Select(x => x.CreateFromServerToClient()).ToList();
            return View(companies);
        }
        public ActionResult Create(long? id)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
           
                var companyData = companyService.GetCompanyResponse(id);
                companyViewModel.Company = companyData.Company!=null ? companyData.Company.CreateFromServerToClient() : new Company();
                companyViewModel.CompanyContacts = companyData.CompanyContacts != null ? companyData.CompanyContacts.Select(x => x.CreateFromServerToClient()).ToList() : new List<CompanyContact>();
                
            companyViewModel.Employees = companyData.Employees != null ? companyData.Employees.Select(x => x.CreateEmployeeDdl()).ToList() : new List<EmployeesDropdownModel>();
            companyViewModel.CompanyStatuses = companyData.CompanyStatuses != null ? companyData.CompanyStatuses.Select(x => x.CreateDropDown()).ToList() : new List<CompanyStatusDropdownModel>();
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
                var companyContacts = companyViewModel.CompanyContacts.Select(x => x.CreateFromClientToServer(companyViewModel.Company));
                companyService.SaveCompany(companyViewModel.Company.CreateFromClientToServer(),companyViewModel.Company.DeletedCompanyContacts, companyContacts);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
    }
}