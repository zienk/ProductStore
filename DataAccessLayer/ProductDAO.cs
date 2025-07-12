using DataAccessLayer.Context;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var context = new MyStoreContext();
                listProducts = context.Products.ToList();
            }
            catch (Exception e) { }

            return listProducts;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Add(p);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using var context = new MyStoreContext();
                var existing = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                context.Remove(existing);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Product GetProductById(int id)
        {
            using var context = new MyStoreContext();
            return context.Products.FirstOrDefault(c => c.ProductId.Equals(id));
        }

    }
}
