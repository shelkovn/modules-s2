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
        }
    }
}
