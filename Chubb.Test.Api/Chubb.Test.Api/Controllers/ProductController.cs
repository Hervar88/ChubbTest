using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chubb.Test.Api.Models;
using Chubb.Test.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chubb.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceProduct _serviceProduct;

        public ProductController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {

            return _serviceProduct.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _serviceProduct.GetAll(id);
        }


        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _serviceProduct.Create(product);
        }

        [HttpPut]
        public Product Put(Product product)
        {
            return _serviceProduct.Update(product);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _serviceProduct.Delete(id);
        }


    }
}
