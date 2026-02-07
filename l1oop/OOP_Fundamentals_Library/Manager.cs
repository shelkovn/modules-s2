using System.Xml.Linq;

namespace OOP_Fundamentals_Library
{
    public class Manager : Staff, IReportable, ITaskmanager
    {
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

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value < 18)
                    throw new ArgumentException("Manager can't be under 18");
                base.Age = value;
            }
        }

        public override int Years
        {
            get { return base.Years; }
            set
            {
                base.Years = value;
                if (value > Age - 18)
                    throw new ArgumentException("Experience cannot be this high");
            }
        }

        public override decimal BonusMultiplier => 0.2m;
        public override decimal SalaryIncrease => 2000m;

        public override void PrintInfo()
        {
            Console.WriteLine($"Manager: {Name}, {Age} years old, Department: {Department}");
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
