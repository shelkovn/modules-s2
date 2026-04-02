using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8medst.Model
{
    public class Document
    {
        IDocumentState State;

        public Document(IDocumentState state)
        {
            State = state;
        }
        public void SetState(IDocumentState state) => State = state;

        // Делегирование поведения текущему состоянию
        public void Print() => State.Print(this);
        public void AddToQueue() => State.AddToQueue(this);
        public void CompletePrinting() => State.CompletePrinting(this);
        public void FailPrinting() => State.FailPrinting(this);
        public void Reset() => State.Reset(this);
    }
}
