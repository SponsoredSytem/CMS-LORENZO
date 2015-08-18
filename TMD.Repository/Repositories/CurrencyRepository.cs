using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class CurrencyRepository: BaseRepository<Currency>, ICurrencyRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CurrencyRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Currency> DbSet
        {
            get { return db.Currency; }
        }
        #endregion
    }
}
