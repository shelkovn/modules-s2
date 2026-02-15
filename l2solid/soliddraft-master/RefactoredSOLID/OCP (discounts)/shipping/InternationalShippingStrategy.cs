using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_
{
    internal class InternationalShippingStrategy : IShippingCostStrategy
    {
        private readonly Dictionary<string, decimal> _destinationRates;

        public InternationalShippingStrategy()
        {
            _destinationRates = new Dictionary<string, decimal>
            {
                ["USA"] = 30.00m,
                ["Europe"] = 35.00m,
                ["Asia"] = 40.00m
            };
        }

        public decimal Calculate(decimal weight, string destination)
        {
            return _destinationRates.TryGetValue(destination, out decimal rate)
                ? rate
                : 50.00m;
        }
    }
}
