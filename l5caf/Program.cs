using l5caf.Model;

namespace l5caf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Folder root = new Folder("root");
            root.Add(new Model.File(100, "biba"));
            root.Add(new Model.File(50, "boba"));

            Folder folder1 = new Folder("sabaka");
            root.Add(folder1);
            folder1.Add(new Model.File(17171717, "budetzhitvechno"));
            Console.WriteLine(root.GetSize());
            
            AdapterClass filesystem = new AdapterClass(root);
            filesystem.WriteFile("sabaka/twoskies", []);
            filesystem.AddFolder("sabaka/watchingitall");
            filesystem.AddFolder("sabaka/watchingitall/fading");
            filesystem.WriteFile("sabaka/aaeieio", []);
            filesystem.AddFolder("sabaka/watchingitall/twosuns");
            filesystem.AddFolder("sabaka/watchingitall/twosuns/watchingthemboth");

            foreach (string str in filesystem.ListItems(""))
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            foreach (string str in filesystem.ListItems("sabaka"))
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            filesystem.DeleteItem("sabaka/aaeieio");
            foreach (string str in filesystem.ListItems("sabaka"))
            {
                Console.WriteLine(str);
            }

            byte[] data = filesystem.ReadFile("biba");
            FileOut(data);

            Folder cloudroot = new Folder("root");
            AdapterClass cloudstorage = new AdapterClass(cloudroot);
            SyncFacade facade = new SyncFacade(filesystem, cloudstorage);

            facade.Backup("sabaka/watchingitall", "coolfolder");
            foreach (string str in cloudstorage.ListItems(""))
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
            //string s0 = "path/1";
            //string s = "path/1/2/3";
            //Console.WriteLine((s.Contains(s0) && s.Substring(0, s0.Length) == s0));
        }

        static void FileOut(byte[] data)
        {
            ConsoleColor[] palette = {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Blue,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Gray,
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.White
            };

            Console.WriteLine("\nDisplay:");

            if (data.Length >= 15 * 14)
            {
                for (int y = 0; y < 15; y++)
                {
                    for (int x = 0; x < 14; x++)
                    {
                        int pixel = data[y * 14 + x];
                        if (pixel < palette.Length)
                        {
                            Console.ForegroundColor = palette[pixel];
                            Console.BackgroundColor = palette[pixel];
                            Console.Write("██");
                        }
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }
            Console.ResetColor();
            Console.WriteLine("L O V E  A N D  P E A C E\n");
        }
    }


}


