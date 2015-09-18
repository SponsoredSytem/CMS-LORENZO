using System.Configuration;
using System.Linq;
using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class CompanyMapper
    {
        public static Company CreateFromClientToServer(this Models.Company source)
        {
            return new Company
            {
                CompanyId = source.CompanyId,
                CompanyName = source.CompanyName,
                LegalName = source.LegalName,
                CompanyDescription = source.CompanyDescription??"",
                Email = source.Email,
                Address = source.Address,
                Fax = source.Fax,
                Telephone = source.Telephone,
                VATNumber = source.VATNumber,
                VATOffice = source.VATOffice,
                Notes = source.Notes??"",
                MunicipalId = source.MunicipalId,
                SourceId = source.SourceId,
                StatusId = source.StatusId,
                EmployeeId = source.AccountHolderId,

                CellPhone = source.CellPhone,
                IndividualFirstName = source.IndividualFirstName,
                IndividualLastName = source.IndividualLastName,
                IsCompany = source.IsCompany,
                Website = source.Website,
                RefrenceCompanyId = source.RefrenceCompanyId,
                BelongingCompanyId = source.BelongingCompanyId,
                CityId = source.CityId,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static Models.Company CreateFromServerToClient(this Company source)
        {
            return new Models.Company
            {
                CompanyId = source.CompanyId,
                CompanyName = source.IsCompany?source.CompanyName:source.IndividualFirstName+" "+source.IndividualLastName,
                LegalName = source.LegalName,
                CompanyDescription = source.CompanyDescription,
                Email = source.Email,
                Address = source.Address,
                Fax = source.Fax,
                Telephone = source.Telephone,
                VATNumber = source.VATNumber,
                VATOffice = source.VATOffice,
                Notes = source.Notes,
                MunicipalId = source.MunicipalId,
                //MunicipalName = source.Municipal.MunicipalName,
                CityName = source.City.CityName,
                CityId=source.CityId,
                SourceId = source.SourceId,
                StatusId = source.StatusId,
                StatusTitle = source.StatusId!=null?source.CompanyStatus.StatusTitle:"",
                AccountHolderId = source.EmployeeId,
                AccountHolderName = string.IsNullOrEmpty(source.EmployeeId)?"":source.AspNetUser.FirstName+" "+source.AspNetUser.LastName,
                AccountHolderEmail = string.IsNullOrEmpty(source.EmployeeId)?"":source.AspNetUser.Email,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,

                CellPhone = source.CellPhone,
                IndividualFirstName = source.IndividualFirstName,
                IndividualLastName = source.IndividualLastName,
                IsCompany = source.IsCompany,
                Website = source.Website,
                RefrenceCompanyId = source.RefrenceCompanyId,
                BelongingCompanyId = source.BelongingCompanyId,

                CompanyEventsUrl = (source.IsCompany && source.Events.Any()) ? ConfigurationManager.AppSettings["HostURL"] + "/Event/Index/" + source.CompanyId : "",
            };
        }
    }
}