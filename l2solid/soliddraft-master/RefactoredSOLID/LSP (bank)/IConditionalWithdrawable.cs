namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public interface IConditionalWithdrawable : IAccount
    {
        bool CanWithdraw(decimal amount);
        void Withdraw(decimal amount);
    }
}

