using System;
using System.Collections.Generic;
using System.Text;

namespace l5caf.Model
{
    abstract class FileSystemItem
    {
        public virtual string Name { get; set; } = $"item{DateTime.Now}";

        public abstract long GetSize();
        public abstract void Add(FileSystemItem item);

        public abstract void Remove(FileSystemItem item);
        public abstract FileSystemItem? GetChild(int index);
    }
}
