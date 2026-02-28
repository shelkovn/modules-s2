
using l4gof.Model;

namespace l4gof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ComputerBuilder builder = new ComputerBuilder();
            //Computer mypc = builder
            //    .WithCPU("cool cpu")
            //    .WithGPU("gta6 ready")
            //    .WithRAM(1000000)
            //    .WithComponent("LED lights")
            //    .Build();
            //Console.WriteLine(mypc.Display());

            //Computer office = new OfficeComputerFactory().Construct();
            //Console.WriteLine(office.Display());

            //Computer gaming = new GamingComputerFactory().Construct();
            //Console.WriteLine(gaming.Display());

            //Computer home = new HomeComputerFactory().Construct();
            //Console.WriteLine(home.Display());


            //Computer pc1 = new GamingComputerFactory().Construct();
            //Computer pc2 = pc1.ShallowCopy();
            //pc2.AdditionalComponents.Add("pc2 component");

            //Console.WriteLine(pc1.Display());
            //Console.WriteLine(pc2.Display());

            //Computer pc3 = new GamingComputerFactory().Construct();
            //Computer pc4 = pc3.DeepCopy();
            //pc4.AdditionalComponents.Add("pc4 component");

            //Console.WriteLine(pc3.Display());
            //Console.WriteLine(pc4.Display());

            PrototypeRegistry prot = PrototypeRegistry.Instance;
            Computer pc1 = prot.GetPrototype("gaming");
            pc1.RAM = 30;
            pc1.AdditionalComponents.Add("pc1 component");
            Computer pc2 = prot.GetPrototype("gaming");

            Console.WriteLine(pc1.Display());
            Console.WriteLine(pc2.Display());

            PrototypeRegistry prot2 = PrototypeRegistry.Instance;
            Console.WriteLine(ReferenceEquals(prot, prot2));
        }
    }
}
