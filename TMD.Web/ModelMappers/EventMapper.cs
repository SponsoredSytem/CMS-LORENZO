using System;
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
                CompanyId = source.CompanyId,
                StatusId = source.EventStatusId,
                ReminderDate = source.ReminderDate,
                ReminderNote = source.ReminderNote,

                EventDateString = source.EventDate.ToString("MM/dd/yyyy HH:mm"),
                ReminderDateString = source.ReminderDate.ToString("MM/dd/yyyy HH:mm"),

                CompanyName = source.Company!=null?source.Company.CompanyName:"",
                StatusTitle = source.EventStatus.StatusTitle,
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
                EventDate = Convert.ToDateTime(source.EventDateString),
                CompanyId = source.CompanyId,
                EventStatusId = source.StatusId,
                ReminderDate = Convert.ToDateTime(source.ReminderDateString),
                ReminderNote = source.ReminderNote,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}