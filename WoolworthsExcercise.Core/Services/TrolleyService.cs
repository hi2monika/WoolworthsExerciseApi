using System.Collections.Generic;
using System.Linq;
using WoolworthsExcercise.Core.Command;
using WoolworthsExcercise.Core.Common.Interfaces.Services;

namespace WoolworthsExcercise.Core.Services
{
    public class TrolleyService : ITrolleyService
    {
        public double GetLowestTrollyPrice(CreateTrolleyCommand trolleyRequest)
        {
            var totalPriceWithPossibleCombination = new List<double>();

            CalculateTrollyPriceRecursive(ref totalPriceWithPossibleCombination, trolleyRequest.Specials, trolleyRequest.Products, trolleyRequest.Quantities, 0);

            return totalPriceWithPossibleCombination.Min();
        }

        private bool ValidSpecial(Special special, IReadOnlyCollection<ProductQuantity> remainingTrolley)
        {
            foreach (var specialQuantity in special.Quantities)
            {
                var remainingQuantity = remainingTrolley.FirstOrDefault(x => x.Name.Equals(specialQuantity.Name));

                if (remainingQuantity?.Quantity < specialQuantity?.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
        private void CalculateTrollyPriceRecursive(ref List<double> totalPriceWithPossibleCombination,
                                            IReadOnlyCollection<Special> specialsProductCombinations,
                                            IReadOnlyCollection<Product> products,
                                            IReadOnlyCollection<ProductQuantity> remainingTrolley,
                                            double total)
        {

            var currentTotal = total + CalculateRemainingTrolleyCost(products, remainingTrolley);
            totalPriceWithPossibleCombination.Add(currentTotal);

            foreach (var specialsProductCombination in specialsProductCombinations)
            {
                if (ValidSpecial(specialsProductCombination, remainingTrolley))
                {
                    var remainingQuanityTrolleyClone = new List<ProductQuantity>();
                    remainingQuanityTrolleyClone.AddRange(remainingTrolley);

                    foreach (var specialQuantity in specialsProductCombination.Quantities)
                    {
                        var filteredProduct = remainingQuanityTrolleyClone
                              .FirstOrDefault(product => product.Name.Equals(specialQuantity.Name));

                        filteredProduct.Quantity = filteredProduct.Quantity - specialQuantity.Quantity;
                    }

                    total += specialsProductCombination.Total;

                    CalculateTrollyPriceRecursive(ref totalPriceWithPossibleCombination, specialsProductCombinations, products, remainingQuanityTrolleyClone, total);
                }
            }
        }
        private double CalculateRemainingTrolleyCost(IReadOnlyCollection<Product> products, IReadOnlyCollection<ProductQuantity> remainingTrolleyProducts)
        {
            double totalRemainingTrolleyCost = 0;
            foreach (var remainingTrolleyProduct in remainingTrolleyProducts)
            {
                var product = products.First(product => product.Name == remainingTrolleyProduct.Name);
                var productPrice = remainingTrolleyProduct.Quantity* product.Price;
                totalRemainingTrolleyCost += productPrice;
            }

            return totalRemainingTrolleyCost;
        }


    }
}
