using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public City GetCity(long cityId)
        {
            return cityRepository.Find(cityId);
        }

        public IEnumerable<City> GetAllCities()
        {
            return cityRepository.GetAll();
        }

        public long SaveCity(City city)
        {
            cityRepository.Add(city);
            cityRepository.SaveChanges();
            return city.CityId;
        }
    }
}

