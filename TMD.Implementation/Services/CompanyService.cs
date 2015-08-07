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

        public CompanyService(ICompanyRepository companyRepository,ICityRepository cityRepository)
        {
            this.companyRepository = companyRepository;
            this.cityRepository = cityRepository;
        }

        public Company GetCompany(long companyId)
        {
            return companyRepository.Find(companyId);
        }

        public CompanyResponseModel GetCompanyResponse(long? companyId)
        {
            CompanyResponseModel responseModel=new CompanyResponseModel();
            //Load Company Data
            if(companyId!=null)
                responseModel.Company = companyRepository.Find((long)companyId);
            //Load Cities
            responseModel.Cities = cityRepository.GetAll().ToList();
            return responseModel;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return companyRepository.GetAll();
        }

        public long SaveCompany(Company company)
        {
            if(company.CompanyId>0)
                companyRepository.Update(company);
            else
                companyRepository.Add(company);
            companyRepository.SaveChanges();
            return company.CompanyId;
        }
    }
}

