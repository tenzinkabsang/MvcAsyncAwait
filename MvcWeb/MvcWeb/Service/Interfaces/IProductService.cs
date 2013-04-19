using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MvcWeb.Models;

namespace MvcWeb.Service.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Task<List<Product>> GetProductsAsync(CancellationToken cancelToken = default(CancellationToken));
    }
}