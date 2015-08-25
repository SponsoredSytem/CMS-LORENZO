using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IEventStatusService
    {
        EventStatus GetEventStatus(long eventStatusId);
        IEnumerable<EventStatus> GetAllEventStatuses();
        IEnumerable<EventStatus> GetAllActiveEventStatuses();
        long SaveEventStatus(EventStatus eventStatus);
    }
}
