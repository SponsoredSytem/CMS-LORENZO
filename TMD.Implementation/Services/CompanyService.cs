﻿using System.Collections.Generic;
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

        public CompanyService(ICompanyRepository companyRepository,ICityRepository cityRepository,ISourceRepository sourceRepository,ICompanyContactRepository companyContactRepository)
        {
            this.companyRepository = companyRepository;
            this.cityRepository = cityRepository;
            this.sourceRepository = sourceRepository;
            this.companyContactRepository = companyContactRepository;
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
           
            return responseModel;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return companyRepository.GetAll();
        }

        public long SaveCompany(Company company, IEnumerable<CompanyContact> companyContacts = null)
        {
            if(company.CompanyId>0)
                companyRepository.Update(company);
            else
                companyRepository.Add(company);

            companyRepository.SaveChanges();

            if (companyContacts != null)
            {
                foreach (var companyContact in companyContacts)
                {
                    companyContact.CompanyId = company.CompanyId;
                    companyContactRepository.Add(companyContact);
                }
                companyContactRepository.SaveChanges();
            }
            
            return company.CompanyId;
        }
    }
}

