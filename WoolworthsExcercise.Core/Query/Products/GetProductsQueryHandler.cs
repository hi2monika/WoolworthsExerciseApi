using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Common.Interfaces;
using WoolworthsExcercise.Core.Common.Interfaces.Services;
using WoolworthsExcercise.Core.ViewModel;

namespace WoolworthsExcercise.Core.Query.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductsViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDataManager _woolworthsApiManager;
        private readonly IProductService _productService;
        private readonly ILogger<GetProductsQueryHandler> _logger;
        public GetProductsQueryHandler(IDataManager woolworthsApiManager, IProductService productService, IMapper mapper, ILogger<GetProductsQueryHandler> logger)
        {
            _woolworthsApiManager = woolworthsApiManager;
            _mapper = mapper;
            _productService = productService;
            _logger = logger;
        }
        public async Task<IEnumerable<ProductsViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Models.Entities.WoolworthsApi.Products>  shopingHistory = null;
            if (request.SortOption == SortOptionsEnum.Recommended)
            {
                var customerShoppingHistory = await _woolworthsApiManager.GetShopperHistoryAsync();
                shopingHistory = customerShoppingHistory.SelectMany(x => x.products).ToList();
            }

            var products = await _woolworthsApiManager.GetProductsAsync();

            var sortProducts = await _productService.SortProductsAsync(products, request.SortOption, shopingHistory);
            return _mapper.Map<IEnumerable<ProductsViewModel>>(sortProducts);

        }

    }
}
