using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IInventoryItemRepositoy inventoryItemRepositoy;
        private readonly IOrderItemsRepository orderItemsRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IColorRepository colorRepository;
        private readonly ICurrencyRepository currencyRepository;
        private readonly ISizeRepository sizeRepository;

        public ProductService(IProductRepository productRepository, IInventoryItemRepositoy inventoryItemRepositoy, IOrderItemsRepository orderItemsRepository, IProductCategoryRepository productCategoryRepository,IColorRepository colorRepository,ICurrencyRepository currencyRepository, ISizeRepository sizeRepository)
        {
            this.productRepository = productRepository;
            this.inventoryItemRepositoy = inventoryItemRepositoy;
            this.orderItemsRepository = orderItemsRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.colorRepository = colorRepository;
            this.currencyRepository = currencyRepository;
            this.sizeRepository = sizeRepository;
        }

        public Product GetProduct(long productId)
        {
            return productRepository.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll().ToList();
        }

        public long SaveProduct(Product product)
        {
            if(product.ProductId>0)
                productRepository.Update(product);
            else
                productRepository.Add(product);
            
            productRepository.SaveChanges();
            return product.ProductId;
        }

        public long GetAvailableProductItem(long productId)
        {
            var itemInInventory = inventoryItemRepositoy.GetItemCountInInventory(productId);
            var itemInOrders = orderItemsRepository.GetItemCountInOrders(productId);
            return itemInInventory - itemInOrders;
        }

        public ProductSearchResponse GetProductSearchResponse(ProductSearchRequest searchRequest)
        {
            return productRepository.GetProductSearchResponse(searchRequest);
        }

        public ProductResponse GetProductResponse(long? productId)
        {
            ProductResponse responseResult = new ProductResponse();
            if (productId != null)
            {
                var product = GetProduct((long)productId);
                if (product != null)
                    responseResult.Product = product;
            }
            responseResult.ProductCategories = productCategoryRepository.GetAll().ToList();
            responseResult.Colors = colorRepository.GetAll().ToList();
            responseResult.Currencies = currencyRepository.GetAll().ToList();
            responseResult.Sizes = sizeRepository.GetAll().ToList();
            return responseResult;
        }

        public ProductSearchResponseByAnyCode GetProductByAnyCode(string code)
        {
            ProductSearchResponseByAnyCode response=new ProductSearchResponseByAnyCode();
            var product = productRepository.GetProductByAnyCode(code);
            if (product != null)
            {
                response.Product = product;
                response.AvailableItems=GetAvailableProductItem(product.ProductId);
            }
            return response;
        }
    }
}
