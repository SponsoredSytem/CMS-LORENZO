using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class EventService:IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public Event GetEvent(int eventId)
        {
            return eventRepository.Find(eventId);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return eventRepository.GetAll();
        }

        public long SaveEvent(Event Event)
        {
            eventRepository.Update(Event);
            eventRepository.SaveChanges();
            return Event.EventId;
        }

        public bool DeleteEvent(Event Event)
        {
            eventRepository.Delete(Event);
            eventRepository.SaveChanges();
            return true;
        }
    }
}
