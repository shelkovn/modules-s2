using ConsoleApp1.RefactoredSOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.ISP
{
    internal class CustomerPortal : IOrderUser
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created by customer");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated by customer");
        }

        public void DeleteOrder(Order order)
        {
            Console.WriteLine("Order deleted by customer");
        }
    }
}
