using Chubb.Test.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chubb.Test.Api.Services
{
    public class ServiceProduct : IServiceProduct
    {

        private static readonly List<Product> products = new List<Product>()
        {
            new Product(){ ProductId = 1, Description = "Yogur", Category = "Lacteos", Price = 10, Amount = 5},
            new Product(){ ProductId = 2, Description = "Arroz 1k", Category = "Abarrotes", Price = 40, Amount = 5},
            new Product(){ ProductId = 3, Description = "Papel", Category = "Abarrotes", Price = 55, Amount = 43},
            new Product(){ ProductId = 4, Description = "Pan bimbo", Category = "Abarrotes", Price = 24, Amount = 5},
            new Product(){ ProductId = 5, Description = "Atun", Category = "Abarrotes", Price = 28, Amount = 9},
            new Product(){ ProductId = 6, Description = "Jamon Pavo", Category = "Abarrotes", Price = 44, Amount = 32},
            new Product(){ ProductId = 7, Description = "Refresco", Category = "Abarrotes", Price =62, Amount = 98},
            new Product(){ ProductId = 8, Description = "Mayonesa", Category = "Abarrotes", Price = 90, Amount = 3},
            new Product(){ ProductId = 9, Description = "Huevo", Category = "Abarrotes", Price = 30, Amount = 1},
        };

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetAll(int id)
        {
            return products.Where(w => w.ProductId == id).FirstOrDefault();
        }


        public Product Create(Product product)
        {
            products.Add(product);

            return product;
        }

        public Product Update(Product product)
        {
            products.ForEach(p => {

                if (p.ProductId == product.ProductId)
                {
                        p.Price = product.Price;
                        p.Amount = product.Amount;
                        p.Category = product.Category;
                        p.Description = product.Description;
                    return;
                }
            });

            return products.Where(w => w.ProductId == product.ProductId).FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var productRemove = products.Where(w => w.ProductId == id).FirstOrDefault();
            products.Remove(productRemove);
            return true;
        }
    }
}
