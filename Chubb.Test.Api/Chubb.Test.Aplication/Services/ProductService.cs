using Chubb.Test.Aplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chubb.Test.Aplication.Services
{
    public class ProductService : IServiceProduct
    {

        private const string BaseUrl = "https://localhost:44370/Product";
        private readonly HttpClient _client;


        public ProductService(HttpClient client)
        {
            _client = client;

        }
        public async Task<Product> Create(Product product)
        {
            var content = JsonConvert.SerializeObject(product);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            var createdProduct = JsonConvert.DeserializeObject<Product>(await httpResponse.Content.ReadAsStringAsync());

            return createdProduct;

        }

        public async Task<bool> Delete(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}{id}");
            var result = true;
            if (!httpResponse.IsSuccessStatusCode)
            {
                result = false;
                throw new Exception("Error");
                
            }

            return result;


        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(content);

            return result;
        }

        public async Task<Product> GetAll(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            var content = JsonConvert.SerializeObject(product);
            var httpResponse = await _client.PutAsync($"{BaseUrl}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("error");
            }

            var createdProduct = JsonConvert.DeserializeObject<Product>(await httpResponse.Content.ReadAsStringAsync());
            return createdProduct;
        }
    }
}
