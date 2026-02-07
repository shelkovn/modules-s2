namespace OOP_Fundamentals_Library
{
    public class Employee : Staff, IReportable
    {
        private string _position = "Unknown";

        public string Position
        {
            get { return _position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Position cannot be empty");
                if (value.Length > 100)
                    throw new ArgumentException("Position too long");
                _position = value;
            }
        }

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value < 14)
                    throw new ArgumentException("Employee can't be under 14");
                base.Age = value;
            }
        }

        public override int Years
        {
            get { return base.Years; }
            set
            {
                base.Years = value;
                if (value > Age - 14)
                    throw new ArgumentException("Experience cannot be this high");
            }
        }

        public override decimal BonusMultiplier => 0.1m;
        public override decimal SalaryIncrease => 1000m;

        public void GenerateReport()
        {
            Console.WriteLine($"Employee Report:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Age: {Age}");
            Console.WriteLine($"  Salary: {Salary}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Employee: {Name}, {Age} years old");
        }
    }
}
