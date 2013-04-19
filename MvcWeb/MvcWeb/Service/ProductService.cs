using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using MvcWeb.Models;
using MvcWeb.Service.Interfaces;

using Newtonsoft.Json;

namespace MvcWeb.Service
{
    public class ProductService : IProductService
    {
        private readonly string _productsUri = Util.GetServiceUri("products");
        
        public List<Product> GetProducts()
        {
            using (WebClient webClient = new WebClient())
            {
                var value = webClient.DownloadString(_productsUri);
                var result = JsonConvert.DeserializeObject<List<Product>>(value);
                return result;
            }
        }

        public async Task<List<Product>> GetProductsAsync(CancellationToken cancelToken = default(CancellationToken))
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_productsUri, cancelToken);

                return await response.Content.ReadAsAsync<List<Product>>();
            }
        }
       
    }
}