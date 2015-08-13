using TMD.Models.DomainModels;
using TMD.Web.Models.Common;

namespace TMD.Web.ModelMappers
{
    public static class CompanyStatusMapper
    {
        public static Models.CompanyStatus CreateFromServerToClient(this CompanyStatus source)
        {
            return new Models.CompanyStatus
            {
                StatusId = source.StatusId,
                StatusTitle = source.StatusTitle,
                SortOrder = source.SortOrder,
                StatusDescription = source.StatusDescription,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static CompanyStatusDropdownModel CreateDropDown(this CompanyStatus source)
        {
            return new CompanyStatusDropdownModel
            {
                Id = source.StatusId,
                Title = source.StatusTitle
            };
        }
    }
}