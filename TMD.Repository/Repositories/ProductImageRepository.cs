using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductImageRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ProductImage> DbSet
        {
            get { return db.ProductImage; }
        }
        #endregion

        public ProductImage GetProductDefaultImage(long productId)
        {
            return DbSet.FirstOrDefault(x => x.IsDefaultImage && x.ProductId==productId);
        }
    }
}
