using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_.discounts
{
    internal class DiscountCalculator
    {
        private readonly Dictionary<string, IDiscountStrategy> _strategies;

        public DiscountCalculator()
        {
            _strategies = new Dictionary<string, IDiscountStrategy>
            {
                ["Regular"] = new RegularCustomerDiscount(),
                ["Premium"] = new PremiumCustomerDiscount(),
                ["VIP"] = new VIPCustomerDiscount(),
                ["Student"] = new StudentDiscount(),
                ["Senior"] = new SeniorDiscount()
            };
        }

        public decimal CalculateDiscount(string customerType, decimal orderAmount)
        {
            if (_strategies.TryGetValue(customerType, out var strategy))
            {
                return strategy.CalculateDiscount(orderAmount);
            }

            return 0;
        }

        public void AddCustomerType(string customerType, IDiscountStrategy strategy)
        {
            _strategies[customerType] = strategy;
        }
    }
}
