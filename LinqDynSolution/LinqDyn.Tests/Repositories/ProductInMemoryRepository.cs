using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDyn.Tests.Repositories
{
    public class ProductInMemoryRepository
    {
        private static List<Product> _products = null;
        public ProductInMemoryRepository()
        {
            if (_products == null)
            {
                _products = GetSampleProducts();
            }
        }
        public List<Product> LoadAll()
        {
            return _products;
        }
        private List<Product> GetSampleProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product() { Id = 3, SortOrder = 3, Name = "123", CreateDate = DateTime.Now });
            products.Add(new Product() { Id = 1, SortOrder = 1, Name = "abc", CreateDate = DateTime.Now.AddHours(-1) });
            products.Add(new Product() { Id = 8, SortOrder = 8, Name = "987", CreateDate = DateTime.Now.AddHours(-10) });
            products.Add(new Product() { Id = 4, SortOrder = 4, Name = "beqakilaba", CreateDate = DateTime.Now.AddHours(-7) });
            products.Add(new Product() { Id = 2, SortOrder = 20, Name = "456", CreateDate = DateTime.Now.AddHours(2) });
            products.Add(new Product() { Id = 6, SortOrder = 6, Name = "test", CreateDate = DateTime.Now.AddHours(1) });
            products.Add(new Product() { Id = 5, SortOrder = 5, Name = "kilaba", CreateDate = DateTime.Now.AddHours(-5) });
            products.Add(new Product() { Id = 10, SortOrder = 10, Name = "bek", CreateDate = DateTime.Now.AddHours(-4) });
            products.Add(new Product() { Id = 7, SortOrder = 7, Name = "beq", CreateDate = DateTime.Now.AddHours(-3) });
            products.Add(new Product() { Id = 9, SortOrder = 9, Name = "beqa", CreateDate = DateTime.Now.AddHours(-2) });

            return products;
        }
    }
}
