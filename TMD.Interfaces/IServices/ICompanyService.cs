using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface ICompanyService
    {
        Company GetCompany(long companyId);
        CompanyResponseModel GetCompanyResponse(long? companyId);
        IEnumerable<Company> GetAllCompanies();
        long SaveCompany(Company company, string contactsToBeDeleted, IEnumerable<CompanyContact> companyContacts = null);
    }
}
