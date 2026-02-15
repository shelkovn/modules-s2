using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_
{
    public class StandardShippingStrategy : IShippingCostStrategy
    {
        public decimal Calculate(decimal weight, string destination)
        {
            return 5.00m + (weight * 0.5m);
        }
    }
}
