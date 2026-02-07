namespace OOP_Fundamentals_Library
{
    public class PayrollSystem
    {
        public void ProcessSalary(IOnPayrollBonusSystem staff)
        {
            staff.ProcessSalary();
        }

        public decimal CalculateBonus(IOnPayrollBonusSystem staff)
        {
            return staff.CalculateBonus();
        }
    }
}
