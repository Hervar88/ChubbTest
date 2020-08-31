using Chubb.Test.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chubb.Test.Api.Services
{
    public interface IServiceProduct
    {
        IEnumerable<Product> GetAll();

        Product GetAll(int id);
        Product Create(Product product);

        Product Update(Product product);

        bool Delete(int id);
    }
}
