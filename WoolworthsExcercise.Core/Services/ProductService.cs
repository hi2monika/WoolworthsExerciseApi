using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Common.Interfaces.Services;

namespace WoolworthsExcercise.Core.Services
{
    public class ProductService: IProductService
    {
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }
        public async Task<IEnumerable<Models.Entities.WoolworthsApi.Products>> SortProductsAsync( IEnumerable<Models.Entities.WoolworthsApi.Products> products
                                                                                            ,SortOptionsEnum sortOptions
                                                                                            , IEnumerable<Models.Entities.WoolworthsApi.Products> PopularProduct = null

            )
        {

            products = sortOptions switch
            {
                SortOptionsEnum.Low => products.OrderBy(product => product.Price),
                SortOptionsEnum.High => products.OrderByDescending(product => product.Price),
                SortOptionsEnum.Ascending => products.OrderBy(product => product.Name),
                SortOptionsEnum.Descending => products.OrderByDescending(product => product.Name),
                SortOptionsEnum.Recommended => await CreateRecomendedProductsCollectionAsync(products, (List<Models.Entities.WoolworthsApi.Products>)PopularProduct),
                _ => throw new ArgumentException(nameof(SortOptionsEnum)),
            };
            return products;
        }
        public async Task<IEnumerable<Models.Entities.WoolworthsApi.Products>> CreateRecomendedProductsCollectionAsync(IEnumerable<Models.Entities.WoolworthsApi.Products> products
                                                                                                                  ,List<Models.Entities.WoolworthsApi.Products> PopularProducts                                                                                                        )
        {
            var sortedPopularProducts = await SortProductsByPopularityAsync(PopularProducts);
            var combinedProducts = new List<Models.Entities.WoolworthsApi.Products>();
            foreach (var sortedPopularProduct in sortedPopularProducts)
            {
                if (products.Any(x => x.Name.Equals(sortedPopularProduct.Name)))
                {
                    combinedProducts.Add(products.Where(x => x.Name == sortedPopularProduct.Name).FirstOrDefault());
                }

            }
            var remainingProducts = products.Except(combinedProducts);
            combinedProducts.AddRange(remainingProducts);
            return await Task.FromResult(combinedProducts);
        }

        private async Task<IEnumerable<Models.Entities.WoolworthsApi.Products>> SortProductsByPopularityAsync(IEnumerable<Models.Entities.WoolworthsApi.Products> PopularProduct)
        {
            var popularProducts = PopularProduct.GroupBy(product => product.Name)
                .Select(g => new Models.Entities.WoolworthsApi.Products
                {
                    Name = g.Key,
                    Price = g.First().Price,
                    Quantity = g.Sum(x => x.Quantity)

                })
                .OrderByDescending(product => product.Quantity);

            return await Task.FromResult(popularProducts);
        }
    }
}
