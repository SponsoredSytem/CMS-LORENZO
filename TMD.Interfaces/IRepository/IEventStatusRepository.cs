using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IEventStatusRepository : IBaseRepository<EventStatus, long>
    {
        IEnumerable<EventStatus> GetAllActiveEventStatuses();
    }
}
