using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ICityService
    {
        City GetCity(long cityId);
        IEnumerable<City> GetAllCities();
        long SaveCity(City city);
    }
}
