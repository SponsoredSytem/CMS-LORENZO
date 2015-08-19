using System;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductImageRepository : IBaseRepository<ProductImage, Guid?>
    {
        ProductImage GetProductDefaultImage(long productId);
    }
}
