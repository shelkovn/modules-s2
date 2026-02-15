using ConsoleApp1.RefactoredSOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.SRP__processor_
{
    internal interface IOrderRepository
    {
        void Add(Order order);
        Order GetById(int id);
        List<Order> GetAll();
    }
}
