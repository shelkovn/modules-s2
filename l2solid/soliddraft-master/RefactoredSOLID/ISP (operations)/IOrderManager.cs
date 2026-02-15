using ConsoleApp1.RefactoredSOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID
{
    internal interface IOrderManager : IOrderUser
    {
        void ProcessPayment(Order order);
        void ShipOrder(Order order);
        void GenerateInvoice(Order order);
        void SendNotification(Order order);
    }
}
