using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IMunicipalService
    {
        Municipal GetMunicipal(long municipalId);
        IEnumerable<Municipal> GetAllMunicipals();
        long SaveMunicipal(Municipal municipal);
        IEnumerable<Municipal> GetMunicipalsByCityId(long cityId);
        bool DeleteMunicipal(Municipal city);
    }
}
