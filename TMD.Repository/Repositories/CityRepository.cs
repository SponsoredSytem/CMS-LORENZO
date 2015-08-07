using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class CityRepository: BaseRepository<City>, ICityRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CityRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<City> DbSet
        {
            get { return db.City; }
        }
        #endregion
    }
}
