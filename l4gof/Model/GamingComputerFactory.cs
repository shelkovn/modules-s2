namespace l4gof.Model
{
    public class GamingComputerFactory:IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 7 7800X3D")
                .WithRAM(24)
                .WithGPU("AMD Radeon RX 5700 XT")
                .WithComponent("1 TB NVMe SSD")
                .Build();
        }
    }
}
