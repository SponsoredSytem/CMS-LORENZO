using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class MunicipalRepository: BaseRepository<Municipal>, IMunicipalRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MunicipalRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Municipal> DbSet
        {
            get { return db.Municipal; }
        }
        #endregion

        public IEnumerable<Municipal> GetMunicipalsByCityId(long cityId)
        {
            return DbSet.Where(x => x.CityId == cityId);
        }
    }
}
