using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class ProductImageService:IProductImageService
    {
        private readonly IProductImageRepository productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            this.productImageRepository = productImageRepository;
        }

        public ProductImage GetProductImage(string imageId)
        {
            return productImageRepository.Find(imageId);
        }

        public bool AddProductImage(ProductImage productImage)
        {
            productImageRepository.Add(productImage);
            productImageRepository.SaveChanges();
            return true;
        }

        public ProductImage GetProductDefaultImage(long productId)
        {
            return productImageRepository.GetProductDefaultImage(productId);
        }
    }
}
