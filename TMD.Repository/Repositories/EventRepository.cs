using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class EventRepository: BaseRepository<Event>, IEventRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EventRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Event> DbSet
        {
            get { return db.Event; }
        }
        #endregion
    }
}
