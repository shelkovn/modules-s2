using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.DIP__services_
{
    internal class NotificationService
    {
        private IEmailService _emailService;

        public NotificationService(IEmailService email)
        {
            _emailService = email;
        }

        public void SendPromotion(string email, string promotion)
        {
            _emailService.SendEmail(email, "Special Promotion", promotion);
        }
    }
}
