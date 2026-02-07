using OOP_Fundamentals_Library;

public class Program
{
    public static void Main()
    {
        var customer = new Customer
        {
            Name = "John",
            Age = 30
        };

        var employee = new Employee
        {
            Name = "Alice",
            Age = 25,
            HasCertification = false,
            Years = 2,
            Salary = 50000,
            Position = "Developer"
        };

        var manager = new Manager
        {
            Name = "Bob",
            Age = 40,
            Years = 12,
            HasCertification = true,
            Salary = 80000,
            Department = "IT"
        };

        manager.AddToTeam(employee);

        employee.Salary = 55000;

        customer.PrintInfo();
        employee.PrintInfo();
        manager.PrintInfo();

        var payroll = new PayrollSystem();
        payroll.ProcessSalary(employee);
        payroll.ProcessSalary(manager);

        var reports = new ReportService();

        reports.GenerateReport(employee);
        reports.GenerateReport(manager);
    }
}