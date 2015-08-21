using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IEventRepository : IBaseRepository<Event, int>
    {
        IEnumerable<Event> GetCompanyEvents(long companyId);
    }
}
