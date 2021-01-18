using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoolworthsExcercise.Core.Common;
using WoolworthsExcercise.Core.Services;
using Xunit;
using DomainProducts = WoolworthsExcercise.Core.Models.Entities.WoolworthsApi.Products;
namespace WooleWorthsExcercise.Core.Services.Test
{
    public class ProductServiceTest
    {
        private Mock<ILogger<ProductService>> _logger;
        [Theory]
        [MemberData(nameof(SortProductsTestCases))]
        public async Task SortProductsTestAsync(IReadOnlyCollection<DomainProducts> products,
         SortOptionsEnum sortOptions,
         IReadOnlyCollection<DomainProducts> recomendedProducts,
         Action<IEnumerable<DomainProducts>> assertion)
        {
            _logger = new Mock<ILogger<ProductService>>();
            var productService = new ProductService(_logger.Object);
            var result = await productService.SortProducts(products, sortOptions, recomendedProducts);
            assertion(result);
        }       
        public static IEnumerable<object[]> SortProductsTestCases
        {
            get
            {
                var Products = new List<DomainProducts>
                {
                    new DomainProducts()
                    {
                       Name = "Apple Product 1",
                       Price = 2.0,
                       Quantity = 1
                    },
                    new DomainProducts()
                    {
                       Name = "Product 2",
                       Price = 3.0,
                       Quantity = 2
                    },
                    new DomainProducts()
                    {
                       Name = "Product 2",
                       Price = 3.0,
                       Quantity = 2
                    },
                    new DomainProducts()
                    {
                       Name = "Product 3",
                       Price = 3.0,
                       Quantity = 2
                    }
                };


                // Low
                Action<IEnumerable<DomainProducts>> assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.First().Price.Should().Be(2.0);
                };

                yield return new object[]
                {
                    Products,
                    SortOptionsEnum.Low,
                    null,
                    assertion
                };

                // High
                assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.First().Price.Should().Be(3.0);
                };

                yield return new object[]
                 {
                    Products,
                    SortOptionsEnum.High,
                    null,
                    assertion
                 };

                // Ascending
                assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.First().Name.Should().Be("Apple Product 1");
                };

                yield return new object[]
                 {
                    Products,
                    SortOptionsEnum.Ascending,
                    null,
                    assertion
                 };

                // Descending
                assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.First().Name.Should().Be("Product 3");
                };

                yield return new object[]
                 {
                    Products,
                    SortOptionsEnum.Descending,
                    null,
                    assertion
                 };

                // Recomended
                var recomendedProducts = new List<DomainProducts>
                {
                    new DomainProducts
                    {
                       Name = "Apple Product 1",
                       Price = 2.0,
                       Quantity = 1
                    },
                    new DomainProducts
                    {
                       Name = "Product 2",
                       Price = 3.0,
                       Quantity = 2
                    },
                    new DomainProducts
                    {
                       Name = "Product 2",
                       Price = 3.0,
                       Quantity = 2
                    }
                };
                assertion = result =>
                {
                    result.Should().NotBeNullOrEmpty();
                    result.First().Name.Should().Be("Product 2");
                    result.Last().Name.Should().Be("Product 3");
                };

                yield return new object[]
                 {
                    Products,
                    SortOptionsEnum.Recommended,
                    recomendedProducts,
                    assertion
                 };

            }
        }
    }
}
