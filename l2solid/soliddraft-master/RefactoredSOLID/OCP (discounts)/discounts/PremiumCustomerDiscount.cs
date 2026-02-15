using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_.discounts
{
    internal class PremiumCustomerDiscount : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.10m;
        }
    }
}
