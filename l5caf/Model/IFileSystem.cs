using System;
using System.Collections.Generic;
using System.Text;

namespace l5caf.Model
{
    internal interface IFileSystem
    {
        List<string> ListItems(string path);
        byte[] ReadFile(string path);
        void WriteFile(string path, byte[] data);
        void DeleteItem(string path);
    }
}
