using System;
using System.Collections.Generic;
using System.Text;

namespace l4gof.Model
{

    public class OfficeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i5")
                .WithRAM(16)
                .WithGPU("Intel i5 built-in graphics lol")
                .WithComponent("256GB SSD")
                .Build();
        }
    }
}
