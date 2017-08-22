using Day1.Library.IDAL;
using Day1.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Library.DAL
{
    public partial class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            List<Product> ProductList = new List<Product>();

            ProductList.Add(new Product() { Id = "1", Cost = 10, Revenue = 110, SellPrice = 21 });
            ProductList.Add(new Product() { Id = "2", Cost = 20, Revenue = 120, SellPrice = 22 });
            ProductList.Add(new Product() { Id = "3", Cost = 30, Revenue = 130, SellPrice = 23 });
            ProductList.Add(new Product() { Id = "4", Cost = 40, Revenue = 140, SellPrice = 24 });
            ProductList.Add(new Product() { Id = "5", Cost = 50, Revenue = 150, SellPrice = 25 });
            ProductList.Add(new Product() { Id = "6", Cost = 60, Revenue = 160, SellPrice = 26 });
            ProductList.Add(new Product() { Id = "7", Cost = 70, Revenue = 170, SellPrice = 27 });
            ProductList.Add(new Product() { Id = "8", Cost = 80, Revenue = 180, SellPrice = 28 });
            ProductList.Add(new Product() { Id = "9", Cost = 90, Revenue = 190, SellPrice = 29 });
            ProductList.Add(new Product() { Id = "10", Cost = 100, Revenue = 200, SellPrice = 30 });
            ProductList.Add(new Product() { Id = "11", Cost = 110, Revenue = 210, SellPrice = 31 });

            return ProductList;
        }

    }
}
