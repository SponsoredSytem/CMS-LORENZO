using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class CompanyContactService : ICompanyContactService
    {
        private readonly ICompanyContactRepository companyContactRepository;

        public CompanyContactService(ICompanyContactRepository companyContactRepository)
        {
            this.companyContactRepository = companyContactRepository;
        }

        public IEnumerable<CompanyContact> GetCompanyContactsByCompanyId(long companyId)
        {
            return companyContactRepository.GetCompanyContactsByCompanyId(companyId);
        }
    }
}

