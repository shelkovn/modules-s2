using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.OCP__discounts_
{
    internal interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal orderAmount);
    }
}
