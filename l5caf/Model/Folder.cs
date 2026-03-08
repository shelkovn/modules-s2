using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace l5caf.Model
{
    internal class Folder: FileSystemItem
    {
        public List<FileSystemItem> Children;

        public Folder(string name)
        {
            this.Name = name;
            this.Children = new List<FileSystemItem>();
        }

        public override string Name { get; set; }

        public override long GetSize()
        {
            long size = 0;
            foreach (FileSystemItem node in Children)
            {
                size += node.GetSize();
            }
            return size;
        }

        public override void Add(FileSystemItem item)
        {
            if (Children.Any(i => i.Name == item.Name))
            {
                Console.WriteLine("нелзя имя занято");
                // throw new InvalidOperationException("нелзя имя занято");
            }
            else
            {
                Children.Add(item);
            }
        }

        public override void Remove(FileSystemItem item)
        {
            if (Children.Contains(item))
            {
                Children.Remove(item);
            }
            else
            {
                Console.WriteLine("нелзя нет такого");
                // throw new InvalidOperationException("нелзя нет такого");
            }
        }

        public override FileSystemItem? GetChild(int index)
        {
            if (index <  Children.Count && index >= 0)
                return Children[index];

            return null;
        }
    }
}
