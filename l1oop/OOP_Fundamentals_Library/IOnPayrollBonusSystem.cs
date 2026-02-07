using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fundamentals_Library
{
    internal interface IOnPayrollBonusSystem
    {
        void ProcessSalary();
        decimal CalculateBonus();
    }
}
