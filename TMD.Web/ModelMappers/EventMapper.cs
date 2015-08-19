using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class EventMapper
    {
        public static EventModel CreateFromServerToClient(this Event source)
        {
            return new EventModel
            {
                EventId = source.EventId,
                EventDescription = source.EventDescription,
                EventDate = source.EventDate,

                RecCreatedByName = source.AspNetUser.FirstName+" "+source.AspNetUser.LastName,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static Event CreateFromClientToServer(this EventModel source)
        {
            return new Event
            {
                EventId = source.EventId,
                EventDescription = source.EventDescription,
                EventDate = source.EventDate,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}