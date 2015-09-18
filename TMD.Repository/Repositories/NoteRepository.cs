using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class NoteRepository: BaseRepository<Note>, INoteRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NoteRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Note> DbSet
        {
            get { return db.Notes; }
        }
        #endregion

        public void DeleteAllNotesById(List<long> contactIds)
        {
            DbSet.Where(x => contactIds.Contains(x.Id)).ToList().ForEach(y => DbSet.Remove(y));
        }

        public IEnumerable<Note> GetNotesByCompanyId(long companyId)
        {
            return DbSet.Where(x => x.CompanyId == companyId);
        }
    }
}
