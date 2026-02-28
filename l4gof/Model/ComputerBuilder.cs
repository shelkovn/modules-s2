using System;
using System.Collections.Generic;
using System.Text;

namespace l4gof.Model
{
    public class ComputerBuilder
    {
        private Computer product = new Computer();

        public ComputerBuilder WithCPU(string cpu)
        {
            product.CPU = cpu;
            return this;
        }
        public ComputerBuilder WithRAM(int ram)
        {
            product.RAM = ram;
            return this;
        }
        public ComputerBuilder WithGPU(string gpu)
        {
            product.GPU = gpu;
            return this;
        }
        public ComputerBuilder WithComponent(string component)
        {
            product.AdditionalComponents.Add(component);
            return this;
        }
        public Computer Build()
        {
            return product;
        }
    }
}
