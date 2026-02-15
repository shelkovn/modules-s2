namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public class CheckingAccount : IOverdraftable, IInterestBearing
    {
        public decimal Balance { get; private set; }
        public decimal OverdraftLimit { get; } = 500m;

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= -OverdraftLimit;
        }

        public void Withdraw(decimal amount)
        {
            if (!CanWithdraw(amount))
                throw new InvalidOperationException("Overdraft limit exceeded");

            Balance -= amount;
        }

        public decimal CalculateInterest()
        {
            return Balance * 0.005m;
        }
    }
}

