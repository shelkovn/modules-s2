using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fundamentals_Library
{
    internal interface IStaff: IPerson
    {
        decimal Salary { get; set; }
        string Department { get; set; }
    }
}
