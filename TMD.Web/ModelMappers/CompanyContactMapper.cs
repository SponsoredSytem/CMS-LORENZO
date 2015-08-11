using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class CompanyContactMapper
    {
        public static Models.CompanyContact CreateFromServerToClient(this CompanyContact source)
        {
            return new Models.CompanyContact
            {
                CompanyContactId = source.CompanyContactId,
                CompanyId = source.CompanyId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Position = source.Position,
                PhoneCell = source.PhoneCell,
                Email = source.Email,
                ContactType = source.ContactType,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static CompanyContact CreateFromClientToServer(this Models.CompanyContact source, Models.Company company)
        {
            return new CompanyContact
            {
                CompanyContactId = source.CompanyContactId,
                CompanyId = source.CompanyId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Position = source.Position,
                PhoneCell = source.PhoneCell,
                Email = source.Email,
                ContactType = source.ContactType,

                RecCreatedBy = company.RecCreatedBy,
                RecCreatedDate = company.RecCreatedDate,
                RecLastUpdatedBy = company.RecLastUpdatedBy,
                RecLastUpdatedDate = company.RecLastUpdatedDate
            };
        }
    }
}