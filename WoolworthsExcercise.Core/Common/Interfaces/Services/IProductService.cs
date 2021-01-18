using System.Collections.Generic;
using System.Threading.Tasks;

namespace WoolworthsExcercise.Core.Common.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Models.Entities.WoolworthsApi.Products>> SortProductsAsync(IEnumerable<Models.Entities.WoolworthsApi.Products> products
                                                                            , SortOptionsEnum sortOptions
                                                                            , IEnumerable<Models.Entities.WoolworthsApi.Products> PopularProduct = null);
        Task<IEnumerable<Models.Entities.WoolworthsApi.Products>> CreateRecomendedProductsCollectionAsync(IEnumerable<Models.Entities.WoolworthsApi.Products> products
                                                                                                     , List<Models.Entities.WoolworthsApi.Products> PopularProduct);
    }
}
