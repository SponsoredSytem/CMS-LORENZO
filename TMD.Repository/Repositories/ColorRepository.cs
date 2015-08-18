using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ColorRepository: BaseRepository<Color>, IColorRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ColorRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Color> DbSet
        {
            get { return db.Color; }
        }
        #endregion
    }
}
