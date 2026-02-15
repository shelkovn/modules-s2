namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{
    public interface IMaturing : IAccount
    {
        DateTime MaturityDate { get; }
        bool IsMatured { get; }
        void WithdrawAtMaturity();
    }
}

