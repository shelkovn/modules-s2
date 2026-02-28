namespace l4gof.Model
{
    public class HomeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 5 1600")
                .WithRAM(16)
                .WithGPU(" AMD Radeon RX 580 8GB")
                .WithComponent("cool keyboard")
                .WithComponent("xbox controller")
                .Build();
        }
    }
}
