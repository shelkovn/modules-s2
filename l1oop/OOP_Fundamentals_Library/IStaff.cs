using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fundamentals_Library
{
    internal interface IStaff: IPerson
    {
        decimal Salary { get; set; }
        int Years { get; set; }
        bool HasCertification { get; set; }
    }
}
