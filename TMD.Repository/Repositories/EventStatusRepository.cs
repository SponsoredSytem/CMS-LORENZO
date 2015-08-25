using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class EventStatusRepository: BaseRepository<EventStatus>, IEventStatusRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EventStatusRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EventStatus> DbSet
        {
            get { return db.EventStatus; }
        }
        #endregion

        public IEnumerable<EventStatus> GetAllActiveEventStatuses()
        {
            return DbSet.Where(x => x.IsActive);
        }
    }
}
