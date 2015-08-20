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
                CompanyId=source.CompanyId,
                CompanyName = source.Company!=null?source.Company.CompanyName:"",
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
                CompanyId = source.CompanyId,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}