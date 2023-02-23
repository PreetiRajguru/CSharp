using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    internal class ReadWrite
    {
       public void ReWrOperation()
        {
            //setting the file path
            string filePath = "D:\\IX\\CSharp\\FileHandling\\a.txt";
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            fileStream.Close();
            Console.WriteLine($"Created a file using FileStream class at {filePath}");

            Console.ReadKey();
        }
    }
}
