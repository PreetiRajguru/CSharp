using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploader
{
    class Program
    {
        static async Task Main()
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
                Console.WriteLine("Invalid file path. Either Source does not exist.");
                Console.Write("Please enter again : ");
                inputPaths = Console.ReadLine();
            }

            string[] sourceFilePaths = inputPaths.Split(',');

            string deleteFile = string.Empty;
            foreach (string fileNotFound in sourceFilePaths)
            {
                if (!File.Exists(fileNotFound))
                {
                    Console.WriteLine($"{fileNotFound} File Does Not Exist");
                    deleteFile = fileNotFound;
                }
            }

            //creating a list of uploaded file names
            List<string> allFiles = new List<string>();
            foreach (string filePath in sourceFilePaths)
            {
                allFiles.Add(filePath);
                allFiles.Remove(deleteFile);
            }

            //creating tasks to upload each file asynchronously
            List<Task> taskList = new List<Task>();
            foreach (string file in allFiles)
            {
                taskList.Add(FileUploadLogic(file, destinationFolder));
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Uploaded Files Sequence : ");

            //waiting for all tasks in list to complete executing method
            await Task.WhenAll(taskList);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("All files uploaded successfully.");
            Console.ReadKey();
        }

        static async Task FileUploadLogic(string filePath, string destinationFolder)
        {
            //file name from file path
            string fileName = Path.GetFileName(filePath);
            string filePathCreate = Path.Combine(destinationFolder, fileName);
            //opening the file for reading
            using (FileStream sourceFile = new FileStream(filePath, FileMode.Open))
            {
                // Create a new file in the destination directory
                using (FileStream destinationFile = new FileStream(filePathCreate, FileMode.Create))
                {
                    // Upload the file asynchronously
                    await sourceFile.CopyToAsync(destinationFile);
                }
            }
            Console.WriteLine(fileName);
        }
    }
}