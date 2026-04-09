using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8medst.Model
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"[Logger] {message}");
        }
    }
}
