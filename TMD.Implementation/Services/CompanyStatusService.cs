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
    }
}

