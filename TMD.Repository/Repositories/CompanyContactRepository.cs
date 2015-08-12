using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class CompanyContactRepository: BaseRepository<CompanyContact>, ICompanyContactRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyContactRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<CompanyContact> DbSet
        {
            get { return db.CompanyContact; }
        }
        #endregion

        public IEnumerable<CompanyContact> GetCompanyContactsByCompanyId(long companyId)
        {
            return DbSet.Where(x => x.CompanyId == companyId);
        }

        public void DeleteAllContactsById(List<long> contactIds)
        {
            DbSet.Where(x=>contactIds.Contains(x.CompanyContactId)).ToList().ForEach(y=>DbSet.Remove(y));
        }
    }
}
