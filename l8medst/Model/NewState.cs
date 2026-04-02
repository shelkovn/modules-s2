using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8medst.Model
{
    public class NewState : IDocumentState
    {
        public void Print(Document document)
        {
            document.SetState(new PrintingState());
            document.AddToQueue();
            Console.WriteLine("[FSM: New -> Printing] Документ в очереди на печать.");
        }

        public void AddToQueue(Document document) 
        {
            //TODO
        }

        public void CompletePrinting(Document document) => Console.WriteLine("[FSM: New] Документ не в очереди или еще не напечатан.");

        public void FailPrinting(Document document) => Console.WriteLine("[FSM: New] Документ не в очереди или еще не напечатан.");

        public void Reset(Document document) => Console.WriteLine("[FSM: New] Документ не в состоянии ошибки.");
    }
}
