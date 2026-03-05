using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace l5caf.Model
{
    internal class AdapterClass: IFileSystem
    {
        private Folder _root;
        
        Folder? FindItemInFolder(Folder parent, string name)
        {
            if (parent.Children.Any(i => i.Name == name))
                return (Folder?)parent.Children.Where(i => i is Folder && i.Name == name).FirstOrDefault();
            return null;
        }

        File? FindFileByPath(string path)
        {
            string[] names = path.Split('/').Where(s => s.Length > 0).ToArray();
            Folder searchin = _root;
            Folder? result = _root;
            for (int i = 0; i < names.Length - 1; i++) // -1 потому что мы ищем папки, а конечный элемент файл)
            {
                result = FindItemInFolder(searchin, names[i]); 
                if (result == null) //нет следующей папки из пути, сносим
                {
                    Console.WriteLine("нет пути неправилно");
                    // throw new InvalidOperationException();
                    return null;
                }
                searchin = result;
            }
            if (!result.Children.Any(i => i is File && i.Name == names[names.Length - 1]))
            {
                Console.WriteLine("нет пути неправилно");
                // throw new InvalidOperationException();
                return null;
            }
            return (File?)result.Children.Where(i => i is File && i.Name == names[names.Length - 1]).FirstOrDefault(); 
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
                    Console.WriteLine("нет пути неправилно");
                    // throw new InvalidOperationException();
                    return null;
                }
                searchin = result;
            }
            return result;
        }

        public AdapterClass(Folder root)
        {
            _root = root;
        }

        public List<string> ListItems(string path)
        {
            Folder? item = FindFolderByPath(path);
            if (item is not null) 
            { 
                return item.Children.Select(c => c.Name).ToList();
            }
            else
            {
                Console.WriteLine("нет пути неправилно");
                throw new InvalidOperationException();
            }
        }

        public byte[] ReadFile(string path)
        {
            File? file = FindFileByPath(path);
            if (file is not null)
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
                Console.WriteLine("нет пути неправилно");
                throw new InvalidOperationException();
            }
        }

        public void WriteFile(string path, byte[] data) // не может создавать папки!! только писать в уже существующие. мне лень реализовывать. можно наверное сделать как FindFolderByPath но из списка досоздавать все оставшиеся
        {
            string name = path.Substring(path.LastIndexOf('/')+1);
            path = path.Remove(path.LastIndexOf('/'));
            Folder? targetfolder = FindFolderByPath(path);
            if (targetfolder is not null)
            {
                targetfolder.Add(new File(data.Length, name));
                //string str = Encoding.UTF8.GetString(data);
                //Console.WriteLine(str); // типа чето сделалм с датой мне лень им хранилище добавлять
            }
            else
            {
                Console.WriteLine("нет пути неправилно");
                throw new InvalidOperationException();
            }
        }
        public void DeleteItem(string path)
        {
            string name = path.Substring(path.LastIndexOf('/') + 1);
            path = path.Remove(path.LastIndexOf('/'));
            Folder? targetfolder = FindFolderByPath(path);
            if (targetfolder is not null && targetfolder.Children.Any(i => i is File && i.Name == name))
            {
                targetfolder.Remove(targetfolder.Children.Where(i => i is File && i.Name == name).First());
            }
            else
            {
                Console.WriteLine("нет пути неправилно");
                throw new InvalidOperationException();
            }
        }
    }
}
