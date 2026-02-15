using ConsoleApp1.RefactoredSOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.DIP__services_
{
    internal class OrderService
    {
        private IEmailService _emailService;
        private ISmsService _smsService;

        public OrderService(IEmailService email, ISmsService sms)
        {
            _emailService = email;
            _smsService = sms;
        }

        public void PlaceOrder(Order order)
        {
            _emailService.SendEmail(order.CustomerEmail, "Order Confirmation", "Your order has been placed");
            _smsService.SendSms(order.CustomerPhone, "Your order has been placed");
        }
    }
}
