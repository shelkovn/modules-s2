namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public class FixedDepositAccount : IMaturing, IInterestBearing
    {
        public decimal Balance { get; private set; }
        public DateTime MaturityDate { get; }
        public bool IsMatured => DateTime.Now >= MaturityDate;

        public FixedDepositAccount(DateTime maturityDate)
        {
            MaturityDate = maturityDate;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void WithdrawAtMaturity()
        {
            if (!IsMatured)
                throw new InvalidOperationException($"Cannot withdraw before {MaturityDate}");

            Balance = 0;
        }

        public decimal CalculateInterest()
        {
            return Balance * 0.05m;
        }
    }
}

