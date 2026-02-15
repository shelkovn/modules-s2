namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public class SavingsAccount : IConditionalWithdrawable, IInterestBearing
    {
        public decimal Balance { get; private set; }
        public decimal MinimumBalance { get; } = 100m;

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= MinimumBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (!CanWithdraw(amount))
                throw new InvalidOperationException("Cannot go below minimum balance");

            Balance -= amount;
        }

        public decimal CalculateInterest()
        {
            return Balance * 0.01m;
        }
    }
}

