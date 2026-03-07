using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace l5caf.Model
{
    internal class AdapterClass: IFileSystem
    {
        private Folder _root;
        private List<string> rootitems = new List<string>();
        
        Folder? FindItemInFolder(Folder parent, string name)
        {
            if (parent.Children.Any(i => i.Name == name))
                return (Folder?)parent.Children.Where(i => i is Folder && i.Name == name).FirstOrDefault();
            return null;
        }

        Folder? FindFolderByPath(string path)
        {
            string[] names = path.Split('/').Where(s => s.Length > 0).ToArray();
            Folder searchin = _root;
            Folder? result = _root;
            for (int i = 0; i < names.Length; i++)
            {
                result = FindItemInFolder(searchin, names[i]);
                if (result == null)
                {
                    Console.WriteLine("нет пути неправилно FindFolderByPath");
                    // throw new InvalidOperationException("нет пути неправилно FindFolderByPath");
                    return null;
                }
                searchin = result;
            }
            return result;
        }

        public AdapterClass(Folder root)
        {
            _root = root;
            rootitems = GetRootItems();
        }

        public List<string> GetRootItems(string path = "")
        {
            Folder? item = FindFolderByPath(path);
            List<string> ans = new List<string>();
            if (item is not null) 
            {  
                ans = item.Children.Select(c => $"{path}/{c.Name}").ToList();
                foreach (Folder f in item.Children.Where(i => i is Folder))
                {
                    ans.AddRange(GetRootItems($"{path}/{f.Name}"));
                }
                return ans;
            }
            else
            {
                throw new InvalidOperationException("нет пути неправилно GetRootItems");
            }
        }

        public List<string> ListItems(string path)
        {
            if (path.Length > 0 && path[0] != '/')
                path = $"/{path}";

            List<string> ans = new List<string>();

            if (rootitems.Any(item => item.Contains(path) && item.Substring(0, path.Length) == path))
                ans.AddRange(rootitems.Where(item => item.Contains(path) && item.Substring(0, path.Length) == path && item.Length > path.Length).Order().ToList());
            return ans;
        }

        public byte[] ReadFile(string path) // он очень тупенький он не разлмчает папки и файлы потому что я не представляю как это сделать без дописывания каких нибудь огромных словарей или новых классов
        {
            if (path[0] != '/')
                path = $"/{path}";

            if (rootitems.Contains(path))
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
                }; //не свастон мамой клянусь 
            }
            else
            {
                Console.WriteLine("нет пути неправилно ReadFile");
                throw new InvalidOperationException("нет пути неправилно ReadFile");
            }
        }

        public void WriteFile(string path, byte[] data)
        {
            if (path[0] != '/')
                path = $"/{path}";
            if (!rootitems.Contains(path))
            {
                rootitems.Add(path);
                string str = Encoding.UTF8.GetString(data);  // я без понятия куда байт дату класть
                //Console.WriteLine(str);
            }
            else
            {
                throw new InvalidOperationException("нет пути неправилно WriteFile");
            }
        }

        public void AddFolder(string path)
        {
            if (path[0] != '/')
                path = $"/{path}";
            if (!rootitems.Contains(path))
            {
                rootitems.Add(path);
            }
            else
            {
                throw new InvalidOperationException("нет пути неправилно AddFolder");
            }
        }

        public void DeleteItem(string path)
        {
            if (path[0] != '/')
                path = $"/{path}";
            if (rootitems.Contains(path))
            {
                rootitems.Remove(path);
                string nofilepath = path.Remove(path.LastIndexOf('/'));
                if (!rootitems.Contains(nofilepath))
                    rootitems.Add(nofilepath);
            }
        }
    }
}
