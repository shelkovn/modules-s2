
using l4gof.Model;

namespace l4gof
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerBuilder builder = new ComputerBuilder();
            Computer mypc = builder
                .WithCPU("cool cpu")
                .WithGPU("gta6 ready")
                .WithRAM(1000000)
                .WithComponent("LED lights")
                .Build();
            Console.WriteLine(mypc.Display());

            Computer office = new OfficeComputerFactory().Construct();
            Console.WriteLine(office.Display());

            Computer gaming = new GamingComputerFactory().Construct();
            Console.WriteLine(gaming.Display());

            Computer home = new HomeComputerFactory().Construct();
            Console.WriteLine(home.Display());
        }
    }
}
