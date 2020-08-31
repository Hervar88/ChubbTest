using Chubb.Test.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chubb.Test.Aplication.Services
{
    public interface IServiceProduct
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetAll(int id);
        Task<Product> Create(Product product);

        Task<Product> Update(Product product);

        Task<bool> Delete(int id);
    }
}
