using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class CompanyStatusRepository: BaseRepository<CompanyStatus>, ICompanyStatusRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyStatusRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<CompanyStatus> DbSet
        {
            get { return db.CompanyStatus; }
        }
        #endregion

        public IEnumerable<CompanyStatus> GetCompanyStatusesBySortOrder()
        {
            return DbSet.OrderBy(x => x.SortOrder);
        }
    }
}
