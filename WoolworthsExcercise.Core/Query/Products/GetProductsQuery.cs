using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.ViewModel;

namespace WoolworthsExcercise.Core.Query.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductsViewModel>>
    {
        public SortOptionsEnum SortOption { get; set; }
        
        public GetProductsQuery(SortOptionsEnum sortOptions )
        {
            SortOption = sortOptions;
        }
    }
}
