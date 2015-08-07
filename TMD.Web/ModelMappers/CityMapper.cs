using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class CityMapper
    {
        public static City CreateFromClientToServer(this Models.City source)
        {
            return new City
            {
                CityId = source.CityId,
                CityName = source.CityName,
                CityDescription = source.CityDescription,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static Models.City CreateFromServerToClient(this City source)
        {
            return new Models.City
            {
                CityId = source.CityId,
                CityName = source.CityName,
                CityDescription = source.CityDescription,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}