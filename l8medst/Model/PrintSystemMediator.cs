using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace l8medst.Model
{
    public class PrintSystemMediator : IMediator
    {
        private Dictionary<string, Action<Document>> handlers;

        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;

        public PrintSystemMediator(Printer printer, PrintQueue printQueue, Logger logger)
        {
            _printer = printer;
            _queue = printQueue;
            _logger = logger;
            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
            handlers= new Dictionary<string, Action<Document>>();
            handlers.Add("QueueDocument", doc =>
            {
                _queue.Add(doc);
            });

            handlers.Add("Enqueued", doc =>
            {
                _logger.WriteMessage($"[Logger] {doc.Name} added to the queue");
            });
        }

        public void Notify(Colleague sender, string ev, Document? document = null)
        {

        }
    }
}
