using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IEventService
    {
        Event GetEvent(int eventId);
        IEnumerable<Event> GetAllEvents();
        long SaveEvent(Event Event);

        bool DeleteEvent(Event Event);
    }
}
