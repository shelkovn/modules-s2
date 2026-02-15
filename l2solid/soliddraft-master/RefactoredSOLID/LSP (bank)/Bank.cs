using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.LSP__bank_
{

    public class Bank
    {
        public void ProcessWithdrawal(IConditionalWithdrawable account, decimal amount)
        {
            if (account.CanWithdraw(amount))
            {
                account.Withdraw(amount);
                Console.WriteLine($"Successfully withdrew {amount}");
            }
            else
            {
                Console.WriteLine("Withdrawal failed: Conditions not met");
            }
        }

        public void ProcessWithdrawal(IOverdraftable account, decimal amount)
        {
            if (account.CanWithdraw(amount))
            {
                account.Withdraw(amount);
                Console.WriteLine($"Successfully withdrew {amount}");
            }
            else
            {
                Console.WriteLine($"Withdrawal failed: Overdraft limit of {account.OverdraftLimit} exceeded");
            }
        }

        public void ProcessWithdrawal(IMaturing account)
        {
            if (account.IsMatured)
            {
                account.WithdrawAtMaturity();
                Console.WriteLine("Successfully withdrew at maturity");
            }
            else
            {
                Console.WriteLine($"Cannot withdraw: Account matures on {account.MaturityDate}");
            }
        }

        public void Transfer(IWithdrawable from, IAccount to, decimal amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
            Console.WriteLine($"Transferred {amount}");
        }
    }
}

