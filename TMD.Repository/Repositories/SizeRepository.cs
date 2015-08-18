using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class SizeRepository: BaseRepository<Size>, ISizeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SizeRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Size> DbSet
        {
            get { return db.Size; }
        }
        #endregion
    }
}
