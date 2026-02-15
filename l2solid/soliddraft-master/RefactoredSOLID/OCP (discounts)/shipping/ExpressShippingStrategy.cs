using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_
{
    internal class ExpressShippingStrategy : IShippingCostStrategy
    {
        public decimal Calculate(decimal weight, string destination)
        {
            return 15.00m + (weight * 1.0m);
        }
    }
}
