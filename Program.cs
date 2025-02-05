using System.IO;

namespace DZ_OTUS_Files
{
    internal class Program
    {
        static async Task Main()
        {

            List<string> pathes=new List<string>() { @"C:\Otus\TestDir1", @"C:\Otus\TestDir2" };
            //string path1 = @"C:\Otus\TestDir1";
            //string path2 = @"C:\Otus\TestDir2";

            foreach (string path in pathes)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    Console.WriteLine($"Создана директория: {path}");
                }
                else
                {
                    Console.WriteLine($"Директория: {path} уже существует!");
                }


                FileClass newFileCreator = new FileClass();
                var result = newFileCreator.CreateFiles(10, "File_example", path);

                
            }

            //await Task.Delay(2000);

            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));

            FileClass newFileCreator2 = new FileClass();

            foreach (string path in pathes)
            {

                await newFileCreator2.WriteNameFiles(path);


            }


            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));

            foreach (string path in pathes)
            {

                await newFileCreator2.ReadFiles(path);


            }
        }
    }
}
