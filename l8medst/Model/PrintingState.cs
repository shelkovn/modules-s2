using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8medst.Model
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document) => Console.WriteLine("[FSM: Printing] Документ уже в печати.");

        public void AddToQueue(Document document) => Console.WriteLine("[FSM: Printing] Документ уже в печати.");


        public void CompletePrinting(Document document)
        {
            document.SetState(new DoneState());
            Console.WriteLine("[FSM: Printing -> Done] Печать успешно завершена."); 
        }

        public void FailPrinting(Document document)
        {
            document.SetState(new ErrorState());
            Console.WriteLine("[FSM: Printing -> Error] Произошла ошибка при печати.");
        }

        public void Reset(Document document) => Console.WriteLine("[FSM: Printing] Документ не в состоянии ошибки.");
    }
}
