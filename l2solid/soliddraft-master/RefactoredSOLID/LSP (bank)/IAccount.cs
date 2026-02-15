namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public interface IAccount
    {
        decimal Balance { get; }
        void Deposit(decimal amount);
    }
}

