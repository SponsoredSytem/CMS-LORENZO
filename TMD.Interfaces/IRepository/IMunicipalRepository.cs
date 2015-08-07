using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IMunicipalRepository : IBaseRepository<Municipal, long>
    {
        IEnumerable<Municipal> GetMunicipalsByCityId(long cityId);
    }
}
