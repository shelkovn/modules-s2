using System;
using System.Collections.Generic;
using System.Text;

namespace l5caf.Model
{
    internal class File : FileSystemItem
    {
        private long _size;

        public File(long size, string name)
        {
            _size = size;
            Name = name;
        }

        public override string Name { get; set; }

        public override long GetSize()
        {
            return _size; 
        }

        public override void Add(FileSystemItem item)
        {
            Console.WriteLine("неа нелзя");
            //throw new InvalidOperationException();
        }

        public override void Remove(FileSystemItem item)
        {
            Console.WriteLine("неа нелзя");
            //throw new InvalidOperationException();
        }

        public override FileSystemItem? GetChild(int index)
        {
            Console.WriteLine("неа нелзя");
            throw new InvalidOperationException();
        }
    }
}

