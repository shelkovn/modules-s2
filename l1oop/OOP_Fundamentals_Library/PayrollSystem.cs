namespace OOP_Fundamentals_Library
{
    public class PayrollSystem
    {
        public void ProcessSalary(Staff staff)
        {
            string staffType = staff.GetType().Name;
            Console.WriteLine($"Processing salary for {staffType.ToLower()} {staff.Name}: {staff.Salary}");
            decimal increase = staff.SalaryIncrease;
            staff.Salary += increase;
        }

        public decimal CalculateBonus(Staff staff)
        {
            decimal bonus = staff.Salary * staff.BonusMultiplier;
            if (staff.Years > 5) bonus += 500;
            if (staff.HasCertification) bonus += 300;
            return bonus;
        }
    }
}
