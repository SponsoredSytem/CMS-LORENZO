using System;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductImageService
    {
        ProductImage GetProductImage(Guid imageId);
        bool AddProductImage(ProductImage productImage);
        ProductImage GetProductDefaultImage(long productId);
    }
}
