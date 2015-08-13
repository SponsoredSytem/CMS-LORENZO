using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICityRepository cityRepository;
        private readonly ISourceRepository sourceRepository;
        private readonly ICompanyContactRepository companyContactRepository;
        private readonly IAspNetUserRepository aspNetUserRepository;
        private readonly ICompanyStatusRepository companyStatusRepository;

        public CompanyService(ICompanyRepository companyRepository,ICityRepository cityRepository,ISourceRepository sourceRepository,ICompanyContactRepository companyContactRepository, IAspNetUserRepository aspNetUserRepository, ICompanyStatusRepository companyStatusRepository)
        {
            this.companyRepository = companyRepository;
            this.cityRepository = cityRepository;
            this.sourceRepository = sourceRepository;
            this.companyContactRepository = companyContactRepository;
            this.aspNetUserRepository = aspNetUserRepository;
            this.companyStatusRepository = companyStatusRepository;
        }

        public Company GetCompany(long companyId)
        {
            return companyRepository.Find(companyId);
        }

        public CompanyResponseModel GetCompanyResponse(long? companyId)
        {
            CompanyResponseModel responseModel=new CompanyResponseModel();
            //Load Company Data
            if (companyId != null)
            {
                responseModel.Company = companyRepository.Find((long)companyId);
                //Load Contacts
                responseModel.CompanyContacts = companyContactRepository.GetCompanyContactsByCompanyId((long)companyId);
            }
                
            //Load Cities
            responseModel.Cities = cityRepository.GetAll().ToList();
            //Load Sources
            responseModel.Sources = sourceRepository.GetAll();

            //Load Employees
            responseModel.Employees = aspNetUserRepository.GetAllUsersOfEmployeeRole();

            //Load Company Statuses
            responseModel.CompanyStatuses = companyStatusRepository.GetCompanyStatusesBySortOrder();

            return responseModel;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return companyRepository.GetAll();
        }

        public long SaveCompany(Company company,string contactsToBeDeleted, IEnumerable<CompanyContact> companyContacts = null)
        {
            if(company.CompanyId>0)
                companyRepository.Update(company);
            else
                companyRepository.Add(company);

            companyRepository.SaveChanges();
            var isAnyChangeInContacts = false;

            //update contacs
            if (companyContacts != null)
            {
                foreach (var companyContact in companyContacts)
                {
                    companyContact.CompanyId = company.CompanyId;
                    companyContactRepository.Update(companyContact);
                    isAnyChangeInContacts = true;
                }
            }

            //delete contacts
            if (!string.IsNullOrEmpty(contactsToBeDeleted))
            {
                var stringListOfIds = contactsToBeDeleted.Split(',');
                var longListOfIds = stringListOfIds.Select(Int64.Parse).ToList();
                companyContactRepository.DeleteAllContactsById(longListOfIds);
                isAnyChangeInContacts = true;
            }
            if (isAnyChangeInContacts)
                companyContactRepository.SaveChanges();
            return company.CompanyId;
        }
    }
}

