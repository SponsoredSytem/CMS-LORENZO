using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class SourceMapper
    {
        public static Source CreateFromClientToServer(this Models.Source source)
        {
            return new Source
            {
                SourceId = source.SourceId,
                SourceName = source.SourceName,
                SourceDescription = source.SourceDescription,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static Models.Source CreateFromServerToClient(this Source source)
        {
            return new Models.Source
            {
                SourceId = source.SourceId,
                SourceName = source.SourceName,
                SourceDescription = source.SourceDescription,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}