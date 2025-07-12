using DataAccessLayer.Models;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public void DeleteProduct(Product p)
            => _productRepository.DeleteProduct(p);

        public Product GetProductById(int id)
            => _productRepository.GetProductById(id);

        public List<Product> GetProducts()
            => _productRepository.GetProducts();

        public void SaveProduct(Product p)
            => _productRepository.SaveProduct(p);

        public void UpdateProduct(Product p)
            => _productRepository.UpdateProduct(p);
    }
}
