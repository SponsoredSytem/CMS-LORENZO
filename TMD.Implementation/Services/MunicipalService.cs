using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class MunicipalService : IMunicipalService
    {
        private readonly IMunicipalRepository municipalRepository;

        public MunicipalService(IMunicipalRepository municipalRepository)
        {
            this.municipalRepository = municipalRepository;
        }

        public Municipal GetMunicipal(long municipalId)
        {
            return municipalRepository.Find(municipalId);
        }

        public IEnumerable<Municipal> GetAllMunicipals()
        {
            return municipalRepository.GetAll();
        }

        public long SaveMunicipal(Municipal municipal)
        {
            municipalRepository.Add(municipal);
            municipalRepository.SaveChanges();
            return municipal.CityId;
        }

        public IEnumerable<Municipal> GetMunicipalsByCityId(long cityId)
        {
            return municipalRepository.GetMunicipalsByCityId(cityId);
        }
    }
}

