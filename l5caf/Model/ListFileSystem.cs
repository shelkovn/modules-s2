using System;
using System.Collections.Generic;
using System.Text;

namespace l5caf.Model
{
    internal class ListFileSystem : IFileSystem // оно нигде не должно использоваться мне просто хотелось иметь его перед глазами чтобы представлять как должен работать этот класс
    {
        private List<string> rootitems = new List<string>();
        public List<string> ListItems(string path)
        {
            if (rootitems.Any(item => item.Contains(path) && item.Substring(0, path.Length) == path))
                return rootitems.Where(item => item.Contains(path) && item.Substring(0, path.Length) == path).ToList();
            else
                throw new InvalidOperationException("нет пути неправилно ListItems");
        }
        public byte[] ReadFile(string path)
        {
            return new byte[]
                {
                    0, 0, 0, 0,10,10, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 7, 9, 9, 9,10,10, 0, 0, 0, 0, 0, 0,
                    0, 0, 7, 9, 9, 9, 9, 9,10,10, 0, 1, 1, 0,
                    0, 0, 7, 9, 9, 9, 9, 9, 9, 9, 1, 1, 1, 0,
                    0, 0, 7, 9, 9, 9, 9, 9, 9, 9, 1, 1, 1, 0,
                    0, 0, 7, 8, 9, 4, 9, 9, 9, 0, 1, 1, 2, 2,
                    0, 7, 8, 8, 6, 4, 4, 4, 9, 0, 1, 2, 2, 2,
                    0, 7, 8, 3, 8, 8, 6, 8, 0, 2, 2, 2, 2, 1,
                    0, 0, 8, 2, 3, 8, 8, 8, 2, 2, 2, 1, 1, 0,
                    0, 0, 5, 6, 6, 5, 6, 6, 2, 2, 1, 1, 0, 0,
                    0, 7, 6, 6, 6, 6, 6, 2, 1, 1, 1, 1, 1, 1,
                    7, 6, 5, 6, 6, 5, 6, 1, 1, 1, 1, 1, 2, 1,
                    6, 6, 6, 6, 6, 6, 1, 2, 2, 2, 1, 2, 1, 1,
                    6, 5, 6, 6, 5, 6, 1, 2, 2, 2, 1, 1, 1, 2,
                    6, 6, 6, 6, 6, 6, 1, 2, 2, 1, 1, 1, 2, 0,
                };
        }
        public void WriteFile(string path, byte[] data)
        {
            rootitems.Add(path);
        }
        public void DeleteItem(string path)
        {
            rootitems.Remove(path);
        }
    }
}
