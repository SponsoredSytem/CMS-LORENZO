using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class EventStatusMapper
    {
        public static EventStatus CreateFromClientToServer(this Models.EventStatus source)
        {
            return new EventStatus
            {
                StatusId = source.StatusId,
                StatusTitle = source.StatusTitle,
                IsActive = source.IsActive,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static Models.EventStatus CreateFromServerToClient(this EventStatus source)
        {
            return new Models.EventStatus
            {
                StatusId = source.StatusId,
                StatusTitle = source.StatusTitle,
                IsActive = source.IsActive,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}