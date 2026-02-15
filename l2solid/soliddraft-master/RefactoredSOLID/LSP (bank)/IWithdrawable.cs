namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public interface IWithdrawable : IAccount
    {
        void Withdraw(decimal amount);
    }
}

