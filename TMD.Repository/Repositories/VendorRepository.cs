﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class VendorRepository: BaseRepository<Vendor>, IVendorRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VendorRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Vendor> DbSet
        {
            get { return db.Vendors; }
        }
        #endregion

        public IEnumerable<Vendor> GetActiveVendors()
        {
            return DbSet.Where(x => x.ActiveFlag);
        }
    }
}
