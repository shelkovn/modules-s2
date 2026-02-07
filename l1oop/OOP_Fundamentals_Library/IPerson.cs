using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fundamentals_Library
{
    internal interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        void PrintInfo();
    }
}
