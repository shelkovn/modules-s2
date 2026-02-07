namespace OOP_Fundamentals_Library
{
    public class ReportService
    {
        public void GenerateReport(IReportable emp)
        {
            emp.GenerateReport();
        }
    }
}
