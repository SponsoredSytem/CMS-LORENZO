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
                CompanyDescription = source.CompanyDescription,
                Email = source.Email,
                Address = source.Address,
                Fax = source.Fax,
                Telephone = source.Telephone,
                VATNumber = source.VATNumber,
                VATOffice = source.VATOffice,
                Notes = source.Notes,
                MunicipalId = source.MunicipalId,
                SourceId = source.SourceId,
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
                CompanyName = source.CompanyName,
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
                CityId=source.Municipal.CityId,
                SourceId = source.SourceId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}