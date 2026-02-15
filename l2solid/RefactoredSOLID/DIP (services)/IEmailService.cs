using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.DIP__services_
{
    internal interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
