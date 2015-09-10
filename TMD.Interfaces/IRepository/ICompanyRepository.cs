using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ICompanyRepository : IBaseRepository<Company, long>
    {
        IEnumerable<Company> GetCompanies();
    }
}
