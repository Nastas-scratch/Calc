using System;
using System.IO;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            if (isTxt(path) && Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                string line = reader.ReadToEnd();
                reader.Close();
                Console.WriteLine(Calculator.Calculate(line));
            }
        }

        static bool isTxt(string path)
        {
            string ex = path.Substring(path.Length - 4).ToLower();
            if (ex == ".txt")
                return true;
            Console.WriteLine("Имя файла задано неверно!");
            return false;
        }

        static bool Exists(string path)
        {
            if (File.Exists(path))
                return true;
            Console.WriteLine("Файл не существует");
            return false;
        }

        
    }
}
