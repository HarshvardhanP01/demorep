namespace Builder_Pattern
{
    public class Computer
    {
        public string? MotherBoard{ get; set; }
        public string? CPU{ get; set; }
        public string? GPU{ get; set; }
        public string? RAM { get; set; }
        public string? Storage { get; set; }
        public string? PSU { get; set; }
        public string? Case { get; set; }

        public override string ToString()
        {
            return $"Computer: [MotherBoard={MotherBoard}, CPU={CPU}, GPU={GPU}, " +
                $"RAM={RAM}, Storage={Storage}, PSU={PSU}, Cabinet={Case}]";
        }
    }

    public interface IComputerBuilder
    {
        IComputerBuilder SetMotherBoard(string? Board);
        IComputerBuilder SetCPU(string? cpu);
        IComputerBuilder SetGPU(string? gpu);
        IComputerBuilder SetRAM(string? ram);
        IComputerBuilder SetStorage(string? storage);
        IComputerBuilder SetPSU(string? psu);
        IComputerBuilder SetCase(string? cabinetType);

        Computer Build();

    }

    public class ComputerBuilder : IComputerBuilder
    {
        private Computer? computer=new Computer();

        public Computer? Build()
        {
            return computer;
        }

        public IComputerBuilder? SetCase(string? cabinetType)
        {
           computer.Case= cabinetType;
            return this;
        }

        public IComputerBuilder? SetCPU(string? cpu)
        {
            computer.CPU= cpu;
            return this;
        }

        public IComputerBuilder? SetGPU(string? gpu)
        {
           computer.GPU= gpu;
            return this;
        }

        public IComputerBuilder? SetMotherBoard(string? Board)
        {
            computer.MotherBoard = Board;
            return this;
        }

        public IComputerBuilder? SetPSU(string? psu)
        {
            computer.PSU= psu;
            return this;
        }

        public IComputerBuilder? SetRAM(string? ram)
        {
            computer.RAM= ram;
            return this;
        }

        public IComputerBuilder? SetStorage(string? storage)
        {
            computer.Storage = storage;
            return this;
        }
    }

    public class Director
    {
        public void ConstructOfficeComputer(IComputerBuilder computerBuilder)
        {
            computerBuilder.SetMotherBoard("Pheonix").SetCPU("Intel core I5 10 Gen").
                SetRAM("16GB DDR4").SetStorage("512GB SSD").SetPSU("Intel").SetCase("Simple");
        }

        public void ConstructGamingComputer(IComputerBuilder computerBuilder) {
            computerBuilder.SetMotherBoard("Intel").SetCPU("Intel core I7 10 Gen").
                SetRAM("16 Gb DDR4").SetGPU("NVIDIA 4GB GTX-1030i")
                .SetStorage("256GB SSD and 1TB HDD").SetPSU("Intel").SetCase("Premium Lenovo");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            
            IComputerBuilder officeComputerBuilder=new ComputerBuilder();
            director.ConstructOfficeComputer(officeComputerBuilder);
            Computer officeComputer=officeComputerBuilder.Build();
            Console.WriteLine(officeComputer);

            IComputerBuilder gamingComputerBuilder = new ComputerBuilder();
            director.ConstructGamingComputer(gamingComputerBuilder);
            Computer gamingComputer = gamingComputerBuilder.Build();
            Console.WriteLine(gamingComputer);

            Console.ReadLine();

        }
    }
}
