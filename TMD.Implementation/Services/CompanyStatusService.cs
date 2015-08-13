using System;
using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class CompanyStatusService : ICompanyStatusService
    {
        private readonly ICompanyStatusRepository companyStatusRepository;

        public CompanyStatusService(ICompanyStatusRepository companyStatusRepository)
        {
            this.companyStatusRepository = companyStatusRepository;
        }

        public IEnumerable<CompanyStatus> GetCompanyStatusesBySortOrder()
        {
            return companyStatusRepository.GetCompanyStatusesBySortOrder();
        }
        public CompanyStatus GetCompanyStatus(long companyStatusId)
        {
            return companyStatusRepository.Find(companyStatusId);
        }
        public long SaveCompanyStatus(CompanyStatus companyStatus)
        {
            if (companyStatus.StatusId > 0)
                companyStatusRepository.Update(companyStatus);
            else
                companyStatusRepository.Add(companyStatus);
            companyStatusRepository.SaveChanges();
            return companyStatus.StatusId;

        }

        public bool DeleteCompanyStatus(CompanyStatus companyStatus)
        {
            try
            {
                companyStatusRepository.Delete(companyStatus);
                companyStatusRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

    }
}

