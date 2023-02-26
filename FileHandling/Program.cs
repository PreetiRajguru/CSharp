using System;
using System.Collections.Generic;
using System.IO;
using ExcelLibrary.SpreadSheet;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUploadWrite operation = new FileUploadWrite();
            operation.UploadWrite();
        }
    }
}
