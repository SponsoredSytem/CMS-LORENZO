using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class SourceRepository: BaseRepository<Source>, ISourceRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SourceRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Source> DbSet
        {
            get { return db.Source; }
        }
        #endregion
    }
}
