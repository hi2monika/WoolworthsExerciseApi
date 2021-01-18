using WoolworthsExcercise.Core.Common.Mappings;
using WoolworthsExcercise.Core.Models.Entities.WoolworthsApi;

namespace WoolworthsExcercise.Core.ViewModel
{
    public class ProductsViewModel : IMapFrom<Products>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
