using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OTUS_Files
{
    public class FileClass
    {
       public int _countFiles;
        public string _nameFirstFile;
        public string _pathDirectory;



        public async Task CreateFiles(int countFiles, string nameFirstFile, string pathDirectory)
        {

            if (countFiles == 0)
            {
                _countFiles = 1;
            }
            else
            {
                _countFiles = countFiles;
            }
            

            _nameFirstFile = nameFirstFile==null?"": nameFirstFile;
            _pathDirectory = pathDirectory;

            string expansion = ".txt";

            for (int i = 0; i < countFiles; i++)
            {
                string newFileName = _nameFirstFile;
                
                    int  counter=i+1;
                    string counterStr=counter.ToString();

                    newFileName = string.Concat(string.Concat(_nameFirstFile, counterStr), expansion);

                    var path= Path.Combine(_pathDirectory, newFileName);

                    if (File.Exists(path) is false) 
                    {
                        try
                        {
                            await using var stream = File.Create(path);

                            Console.WriteLine($"Создан файл {newFileName}{expansion}");
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        } 
                      

                    }


             }
        
        }

        public async Task WriteNameFiles(string pathDirectory) 
        {
            var directory = new DirectoryInfo(pathDirectory);

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.IsReadOnly is false) 
                { 
                try
                {

                File.WriteAllText(file.FullName, file.Name, Encoding.UTF8);
                Console.WriteLine($"Записали имя файла {file.Name}");

                string currentDateTime = $"\n{DateTime.Now.ToString("dd MMMM yyyy|HH:mm:ss")}";
                File.AppendAllText(file.FullName, currentDateTime, Encoding.UTF8);
                Console.WriteLine($"Записали дату в файл {file.Name}");
                }
                catch (UnauthorizedAccessException ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
                }

            }
        }

        public async Task ReadFiles(string pathDirectory)
        {
            var directory = new DirectoryInfo(pathDirectory);

            Console.WriteLine();
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"Читаем файл {file.Name}");
                string fileText = File.ReadAllText(file.FullName);
                Console.WriteLine($" {fileText}");
                Console.WriteLine();

            }
        }
    }
}
