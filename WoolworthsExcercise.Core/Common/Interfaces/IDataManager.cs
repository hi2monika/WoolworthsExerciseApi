using System.Collections.Generic;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Models.Entities.WoolworthsApi;

namespace WoolworthsExcercise.Core.Common.Interfaces
{
    public interface IDataManager
    {
        Task<IReadOnlyCollection<Products>> GetProductsAsync();

        Task<IReadOnlyCollection<Customer>> GetShopperHistoryAsync();
    }
}
