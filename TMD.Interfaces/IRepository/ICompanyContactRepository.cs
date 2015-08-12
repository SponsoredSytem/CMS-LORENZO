using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ICompanyContactRepository : IBaseRepository<CompanyContact, long>
    {
        IEnumerable<CompanyContact> GetCompanyContactsByCompanyId(long companyId);
        void DeleteAllContactsById(List<long> contactIds);
    }
}
