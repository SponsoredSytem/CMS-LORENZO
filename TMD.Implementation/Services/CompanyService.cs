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
        private readonly INotesCategoryRepository notesCategoryRepository;

        public CompanyService(ICompanyRepository companyRepository,ICityRepository cityRepository,ISourceRepository sourceRepository,ICompanyContactRepository companyContactRepository, IAspNetUserRepository aspNetUserRepository, ICompanyStatusRepository companyStatusRepository, INotesCategoryRepository notesCategoryRepository)
        {
            this.companyRepository = companyRepository;
            this.cityRepository = cityRepository;
            this.sourceRepository = sourceRepository;
            this.companyContactRepository = companyContactRepository;
            this.aspNetUserRepository = aspNetUserRepository;
            this.companyStatusRepository = companyStatusRepository;
            this.notesCategoryRepository = notesCategoryRepository;
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
                responseModel.CompanyContacts = companyContactRepository.GetCompanyContactsByCompanyId((long)companyId).ToList();
            }
                
            //Load Cities
            responseModel.Cities = cityRepository.GetAll().ToList();
            //Load Sources
            responseModel.Sources = sourceRepository.GetAll().ToList();

            //Load Employees
            responseModel.Employees = aspNetUserRepository.GetAllUsersOfEmployeeRole().ToList();

            //Load Company Statuses
            responseModel.CompanyStatuses = companyStatusRepository.GetCompanyStatusesBySortOrder().ToList();

            //Load Companies And Individuals
            responseModel.CompaniesAndIndividuals = companyRepository.GetAll().ToList();

            //Load Companies
            responseModel.Companies = companyRepository.GetCompanies().ToList();

            //Notes Categories
            responseModel.NotesCategories = notesCategoryRepository.GetAll().ToList();

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

