using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductImageRepository : IBaseRepository<ProductImage, string>
    {
        ProductImage GetProductDefaultImage(long productId);
    }
}
