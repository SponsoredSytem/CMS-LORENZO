using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class EventStatusService : IEventStatusService
    {
        private readonly IEventStatusRepository eventStatusRepository;

        public EventStatusService(IEventStatusRepository eventStatusRepository)
        {
            this.eventStatusRepository = eventStatusRepository;
        }

        public EventStatus GetEventStatus(long eventStatusId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventStatus> GetAllEventStatuses()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventStatus> GetAllActiveEventStatuses()
        {
            return eventStatusRepository.GetAllActiveEventStatuses();
        }

        public long SaveEventStatus(EventStatus eventStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}

