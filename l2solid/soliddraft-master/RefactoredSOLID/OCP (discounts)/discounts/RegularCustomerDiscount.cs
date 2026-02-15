using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_.discounts
{
    internal class RegularCustomerDiscount : IDiscountStrategy
    {
        public decimal CalculateDiscount(decimal orderAmount)
        {
            return orderAmount * 0.05m;
        }
    }
}
