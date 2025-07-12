﻿using DataAccessLayer;
using DataAccessLayer.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product p)
            => ProductDAO.DeleteProduct(p);

        public Product GetProductById(int id)
            => ProductDAO.GetProductById(id);

        public List<Product> GetProducts()
            => ProductDAO.GetProducts();

        public void SaveProduct(Product p)
            => ProductDAO.SaveProduct(p);

        public void UpdateProduct(Product p)
            => ProductDAO.UpdateProduct(p);
    }
}
