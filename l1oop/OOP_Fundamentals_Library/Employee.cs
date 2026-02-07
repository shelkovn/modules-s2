namespace OOP_Fundamentals_Library
{
    public class Employee: IStaff, IOnPayrollBonusSystem, IReportable
    {
        private string _name = "NoName";
        private int _age;
        private decimal _salary;
        private string _position = "Unknown";
        private int _years;
        private bool _hasCertification;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                if (value.Length > 100)
                    throw new ArgumentException("Name too long");
                if (!value.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
                    throw new ArgumentException("Name contains invalid characters");
                _name = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 14)
                    throw new ArgumentException("Employee can't be under 14");
                if (value > 120)
                    throw new ArgumentException("Age is too high");
                _age = value;
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

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

        public int Years
        {
            get { return _years; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Years cannot be negative");
                if (value > Age - 14)
                    throw new ArgumentException("Experience cannot be this high");
                _years = value;
            }
        }

        public bool HasCertification
        {
            get { return _hasCertification; }
            set { _hasCertification = value; }
        }

        public void ProcessSalary()
        {
            Console.WriteLine($"Processing salary for employee {Name}: {Salary}");
            Salary += 1000;
        }

        public decimal CalculateBonus()
        {
            decimal bonus = Salary * 0.1m;
           
            if (Years > 5)
            {
                bonus += 500;
            }
            if (HasCertification)
            {
                bonus += 300;
            }

            return bonus;
        }

        public void GenerateReport()
        {
            Console.WriteLine($"Employee Report:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Age: {Age}");
            Console.WriteLine($"  Salary: {Salary}"); 
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Employee: {_name}, {Age} years old");
        }

        //public void IncreaseSalary(decimal amount)
        //{
        //    Salary += amount;
        //}
    }
}
