using System;
using System.Collections.Generic;
using System.Text;

namespace l5caf.Model
{
    internal class SyncFacade
    {
        private IFileSystem _sourceFS;
        private IFileSystem _targetFS;
        public SyncFacade(IFileSystem source, IFileSystem target)
        {
            _sourceFS = source;
            _targetFS = target;
        }

        public void SyncFolder(string sourcePath, string targetPath)
        {
            try
            {
                var items = _sourceFS.ListItems(sourcePath);
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        string filename = item.Replace($"{sourcePath}/", "");

                        if (_targetFS.ListItems(targetPath).Contains($"{targetPath}{filename}"))
                            _targetFS.DeleteItem($"{targetPath}{filename}");

                        _targetFS.WriteFile($"{targetPath}{filename}", _sourceFS.ReadFile(item));

                    }
                    Console.WriteLine("Синхронизация завершена.");
                }
                else
                {
                    Console.WriteLine("Нет файлов для копирования");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Backup(string sourcePath, string targetPath)
        {
            try
            {
                var items = _sourceFS.ListItems(sourcePath);
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        string filename = item.Replace($"{sourcePath}/", "");

                        if (_targetFS.ListItems(targetPath).Contains($"{targetPath}{filename}"))
                            _targetFS.DeleteItem($"{targetPath}{filename}");

                        _targetFS.WriteFile($"{targetPath}{filename}", _sourceFS.ReadFile(item));

                    }
                    Console.WriteLine("Синхронизация завершена.");
                }
                else
                {
                    Console.WriteLine("Нет файлов для копирования");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
