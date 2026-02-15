using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.SRP__processor_
{
    internal interface INotificationService
    {
        void SendEmail(string to, string message);
    }
}
