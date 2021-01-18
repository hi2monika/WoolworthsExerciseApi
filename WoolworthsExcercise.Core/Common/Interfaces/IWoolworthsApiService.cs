using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Models.Entities.WoolworthsApi;

namespace WoolworthsExcercise.Core.Common.Interfaces
{
    public interface IWoolworthsApiService
    {
        [Get("/api/resource/products?token={token}")]
        Task<IReadOnlyCollection<Products>> GetProductsAsync(string token);

        [Get("/api/resource/shopperHistory?token={token}")]
        Task<IReadOnlyCollection<Customer>> GetShopperHistoryAsync(string token);
    }
}
