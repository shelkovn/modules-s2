using l7behpat.Model;

namespace l7behpat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventMonitor jajah = new EventMonitor();
            jajah.OnMetricExceeded += e => Console.WriteLine("ну че там твин получилось проц разогнать?");
            jajah.CheckMetric();
        }
    }
}
