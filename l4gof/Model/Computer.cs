using System;
using System.Collections.Generic;
using System.Text;

namespace l4gof.Model
{
    public class Computer
    {
        internal string CPU;
        internal int RAM;
        internal string GPU;
        internal List<string> AdditionalComponents = new List<string>();
        public string Display()
        {
            string none = "unknown";
            string display = $"cpu: {(CPU is null ? none : CPU)}, ram: {RAM} gb, gpu: : {(GPU is null ? none : GPU)}\n";
            if (AdditionalComponents is null) return display;

            display += $"additional ({AdditionalComponents.Count()}): \n";
            foreach (string component in AdditionalComponents)
            {
                display += $"{component} \n";
            }
            return display;
        }

        public Computer ShallowCopy()
        {
            return (Computer)MemberwiseClone();
        }

        public Computer DeepCopy()
        {
            Computer other = (Computer)MemberwiseClone();
            if (AdditionalComponents is not null)
                other.AdditionalComponents = new List<string>(this.AdditionalComponents);
            return other;
        }
    }
}
