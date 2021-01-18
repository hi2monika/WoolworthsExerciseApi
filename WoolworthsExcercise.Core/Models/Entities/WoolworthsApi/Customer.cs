using System.Collections.Generic;

namespace WoolworthsExcercise.Core.Models.Entities.WoolworthsApi
{
    public class Customer
    {
        public int customerId { get; set; }
        public IEnumerable<Products> products { get; set; }
    }
}
