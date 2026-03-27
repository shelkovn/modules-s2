using System;
using System.Collections.Generic;
using System.Text;

namespace l7behpat.Model
{
    public interface IFormatStrategy
    {
        string Format(string message, DateTime timestamp);
    }
}
