using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID.SRP__processor_
{
    internal class ExportService : IExportService
    {
        public void ExportToExcel(List<Order> orders, string filePath)
        {
            Console.WriteLine($"Exporting orders to {filePath}");
        }
    }
}
