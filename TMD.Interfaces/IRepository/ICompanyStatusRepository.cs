using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ICompanyStatusRepository : IBaseRepository<CompanyStatus, long>
    {
        IEnumerable<CompanyStatus> GetCompanyStatusesBySortOrder();
    }
}
