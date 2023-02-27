using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelLibrary.SpreadSheet;

namespace FileHandling
{
    internal class FileUploadWrite
    {
        public void UploadWrite()
        {
            //accepting destination folder path
            Console.Write("Enter the destination folder path : ");
            string destinationFolder = Console.ReadLine();

            while (!(Path.IsPathRooted(destinationFolder)))
            {
                Console.Write("Invalid file path.Please enter again : ");
                destinationFolder = Console.ReadLine();
            }

            //creating destination folder if it does not exist
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
                Console.WriteLine("Destination Folder Created" + destinationFolder);
            }

            //accepting the source file paths of files to upload
            Console.WriteLine("Enter the source file paths to upload (seperated by commas) : ");
            string inputPaths = Console.ReadLine();

            while (!(Path.IsPathRooted(inputPaths) || File.Exists(inputPaths)))
            {
                Console.WriteLine("Invalid file path. Source does not exist.");
                Console.Write("Please enter again : ");
                inputPaths = Console.ReadLine();
            }

            string[] sourceFilePaths = inputPaths.Split(',');

            //creating a list of uploaded file names
            List<string> uploadedFileNames = new List<string>();

            //uploading each file into destination folder
            foreach (string inputPath in sourceFilePaths)
            {
                string sourceFilePath = inputPath.Trim();
                string fileName = Path.GetFileName(sourceFilePath);
                string destinationFilePath = Path.Combine(destinationFolder, fileName);

                //creating file in the destination folder if it does not exist 
                if (!File.Exists(destinationFilePath))
                {
                    try
                    {
                        File.Create(destinationFilePath).Close();
                        Console.WriteLine("Created new file at " + destinationFilePath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something went wrong while creating the file at " + destinationFilePath + e.Message);
                        continue;
                    }
                }
                try
                {
                    //copying the source file contents to the destination file
                    using (FileStream originalFileStream = File.OpenRead(sourceFilePath))
                    {
                        using (FileStream outputFileStream = File.OpenWrite(destinationFilePath))
                        {
                            originalFileStream.CopyTo(outputFileStream);
                        }
                    }
                    Console.WriteLine("Copied contents of " + sourceFilePath + " to " + destinationFilePath);
                    uploadedFileNames.Add(fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong while copying contents of " + sourceFilePath + " to " + destinationFilePath + ex.Message);
                }
            }

            //displaying the list of uploaded file names with numbers
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Uploaded Files Are : ");
            for (int i = 0; i < uploadedFileNames.Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + uploadedFileNames[i]);
            }

            //displaying total files in the directory to select for writing
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Files in the destination directory are : ");
            List<string> list = new List<string>();
            string[] fileArray = Directory.GetFiles(destinationFolder);
            for (int i = 0; i < fileArray.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + Path.GetFileName(fileArray[i]));
                list.Add(fileArray[i]);
            }

            //accepting user input for selecting the number of file to write
            Console.Write("Enter the number of file to write to : ");
            int fileNumToWrite;
            while (!int.TryParse(Console.ReadLine(), out fileNumToWrite) || (fileNumToWrite < 1 || fileNumToWrite > list.Count))
            {
                Console.Write("Please enter valid input : ");
            }

            //finding the file name in the list
            string writeFileName = list[fileNumToWrite - 1];
            string writeFilePath = Path.Combine(destinationFolder, writeFileName);

            //opening selected file for writing
            string selectedFilePath = writeFilePath;
            string extension = Path.GetExtension(writeFilePath);
            switch (extension)
            {
                case ".txt":
                    StreamWriter sw = new StreamWriter(selectedFilePath);
                    Console.Write("Enter the data you want to write to the text file : ");
                    string data = Console.ReadLine();
                    sw.Write(data);
                    sw.Close();
                    Console.WriteLine("Data written to the file successfully.");
                    break;

                case ".xls":
                    //creating a new excel workbook
                    Workbook workbook = new Workbook();
                    Worksheet worksheet = new Worksheet("Sheet 1");
                    workbook.Worksheets.Add(worksheet);

                    //writing data to cells in the worksheet
                    //worksheet.Cells[rowIndex,colIndex] = cellValue;
                    Console.WriteLine("Enter row index where you want to write :");
                    int rowindex = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter col index where you want to write :");
                    int colindex = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter data to fill in the cell : ");
                    string exldata = Console.ReadLine();

                    worksheet.Cells[rowindex, colindex] = new Cell(exldata);
                    Console.WriteLine("Data written successfully.");

                    //saving the workbook to the file
                    workbook.Save(selectedFilePath);
                    break;

                case ".jpg":
                    Console.WriteLine($"Cannot write into {selectedFilePath}.");
                    break;

                case ".png":
                    Console.WriteLine($"Cannot write into {selectedFilePath}.");
                    break;

                default:
                    Console.WriteLine($"Cannot write into {selectedFilePath}.");
                    break;
            }
            Console.ReadKey();
        }
    }
}
