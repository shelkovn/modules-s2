using System.Xml.Linq;

namespace OOP_Fundamentals_Library
{
    public class Manager: IStaff, IOnPayrollBonusSystem, ITaskmanager, IReportable
    {
        private string _name = "NoName";
        private int _age;
        private decimal _salary;
        private int _years;
        private bool _hasCertification;
        private string _department = "Unknown";

        private readonly List<Employee> _team = new();
        public IReadOnlyList<Employee> Team => _team.AsReadOnly();
        public void AddToTeam(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            if (_team.Contains(employee))
                throw new InvalidOperationException("Employee already in team");

            _team.Add(employee);
        }

        public bool RemoveFromTeam(Employee employee)
        {
            return _team.Remove(employee);
        }

        public int TeamSize => _team.Count;

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
                if (value < 18)
                    throw new ArgumentException("Manager can't be under 18");
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

        public string Department
        {
            get { return _department; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Department cannot be empty");
                if (value.Length > 100)
                    throw new ArgumentException("Department too long");
                _department = value;
            }
        }
        public int Years
        {
            get { return _years; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Years cannot be negative");
                if (value > Age - 18)
                    throw new ArgumentException("Experience cannot be this high");
                _years = value;
            }
        }

        public bool HasCertification
        {
            get { return _hasCertification; }
            set { _hasCertification = value; }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Manager: {Name}, {Age} years old, Department: {Department}");
        }
        
        public void ProcessSalary()
        {
            Console.WriteLine($"Processing salary for manager {Name}: {Salary}");
            Salary += 2000;
            
        }

        public decimal CalculateBonus()
        {
            decimal bonus = Salary * 0.2m;

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
            Console.WriteLine($"Manager Report:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Department: {Department}");
            Console.WriteLine($"  Team Size: {Team.Count}");
        }

        public void AssignTaskToEmployee(Employee emp, string task)
        {
            Console.WriteLine($"Assigning task '{task}' to {emp.Name}");
        }
    }
}
