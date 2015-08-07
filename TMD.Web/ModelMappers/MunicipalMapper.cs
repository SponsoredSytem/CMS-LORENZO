using TMD.Web.Models;
using TMD.Web.Models.ApiModels;

namespace TMD.Web.ModelMappers
{
    public static class MunicipalMapper
    {
        public static Municipal CreateFromServerToClient(this TMD.Models.DomainModels.Municipal municipal)
        {
            return new Municipal
            {
                MunicipalId = municipal.MunicipalId,
                MunicipalName = municipal.MunicipalName,
                MunicipalDescription = municipal.MunicipalDescription,
                CityId = municipal.CityId,
                RecCreatedBy = municipal.RecCreatedBy,
                RecCreatedDate = municipal.RecCreatedDate,
                RecLastUpdatedBy = municipal.RecLastUpdatedBy,
                RecLastUpdatedDate = municipal.RecLastUpdatedDate
            };
        }
        public static MunicipalApiModel CreateFromServerToClientApi(this TMD.Models.DomainModels.Municipal municipal)
        {
            return new MunicipalApiModel
            {
                MunicipalId = municipal.MunicipalId,
                MunicipalName = municipal.MunicipalName
            };
        }
    }
}