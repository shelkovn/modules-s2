using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_
{
    internal class ShippingCostCalculator
    {
        private readonly Dictionary<string, IShippingCostStrategy> _strategies;

        public ShippingCostCalculator()
        {
            _strategies = new Dictionary<string, IShippingCostStrategy>
            {
                ["Standard"] = new StandardShippingStrategy(),
                ["Express"] = new ExpressShippingStrategy(),
                ["Overnight"] = new OvernightShippingStrategy(),
                ["International"] = new InternationalShippingStrategy()
            };
        }

        public decimal CalculateShippingCost(string shippingMethod, decimal weight, string destination)
        {
            if (_strategies.TryGetValue(shippingMethod, out var strategy))
            {
                return strategy.Calculate(weight, destination);
            }

            return 0;
        }

        public void AddShippingMethod(string methodName, IShippingCostStrategy strategy)
        {
            _strategies[methodName] = strategy;
        }
    }
}
