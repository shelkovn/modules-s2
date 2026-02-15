namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public interface IOverdraftable : IAccount
    {
        decimal OverdraftLimit { get; }
        bool CanWithdraw(decimal amount);
        void Withdraw(decimal amount);
    }
}

