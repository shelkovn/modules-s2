using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID
{
    internal interface IDatabaseManager
    {
        void GenerateReport(DateTime from, DateTime to);
        void ExportToExcel(string filePath);
        void BackupDatabase();
        void RestoreDatabase();
    }
}
