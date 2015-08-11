using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ICompanyContactService
    {
        IEnumerable<CompanyContact> GetCompanyContactsByCompanyId(long companyId);
    }
}
