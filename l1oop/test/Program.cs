using OOP_Fundamentals_Library;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer
            {
                Name = "John",
                Age = 30
            };

            var employee1 = new Employee
            {
                Name = "Alice",
                Age = 25,
                HasCertification = false,
                Years = 2,
                Salary = 50000,
                Position = "Developer"
            };

            var manager1 = new Manager
            {
                Name = "Bob",
                Age = 40,
                Years = 12,
                HasCertification = true,
                Salary = 80000,
                Department = "IT"
            };

            manager1.AddToTeam(employee1);

            employee1.Salary = 55000;

            customer.PrintInfo();
            employee1.PrintInfo();
            manager1.PrintInfo();

            var payroll = new PayrollSystem();
            payroll.ProcessSalary(employee1);
            payroll.ProcessSalary(manager1);

            var reports = new ReportService();

            reports.GenerateReport(employee1);
            reports.GenerateReport(manager1);
        }
    }
}
