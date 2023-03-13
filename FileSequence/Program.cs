using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static FileSequence.Constants;

namespace FileUploader
{
    class Program
    {
        static async Task Main()
        {
            //accepting destination folder path
            Console.Write(destinationInput);
            string destinationFolder = Console.ReadLine();

            while (!(Path.IsPathRooted(destinationFolder)))
            {
                Console.Write(invalidPath);
                destinationFolder = Console.ReadLine();
            }

            //creating destination folder if it does not exist
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
                Console.WriteLine(folderCreated + destinationFolder);
            }

            //accepting the source file paths of files to upload
            Console.WriteLine(sourceInputPaths);
            string inputPaths = Console.ReadLine();
            while (!Path.IsPathRooted(inputPaths))
            {
                Console.WriteLine(invalidPath);
                inputPaths = Console.ReadLine();
            }

            string[] sourceFilePaths = inputPaths.Split(',');

            List<string> deleteFiles = new List<string>();
            foreach (string invalidFile in sourceFilePaths)
            {
                if (!File.Exists(invalidFile))
                {
                    Console.WriteLine(sourceNotExist);
                    deleteFiles.Add(invalidFile);
                }
            }

            //creating a list of uploaded file names
            List<string> allFiles = new List<string>();
            foreach (string filePath in sourceFilePaths)
            {
                allFiles.Add(filePath);
            }
            allFiles.RemoveAll(x => deleteFiles.Contains(x));

            //creating tasks to upload each file asynchronously
            List<Task> taskList = new List<Task>();
            foreach (string file in allFiles)
            {
                taskList.Add(FileUploadLogic(file, destinationFolder));
            }
            Console.WriteLine(partitionString);
            Console.WriteLine(fileUploadSequence);

            //waiting for all tasks in list to complete executing method
            await Task.WhenAll(taskList);
            Console.WriteLine(partitionString);
            Console.WriteLine(allFilesUploaded);
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
                //creating a new file in the destination directory
                using (FileStream destinationFile = new FileStream(filePathCreate, FileMode.Create))
                {
                    //uploading the file asynchronously
                    await sourceFile.CopyToAsync(destinationFile);
                }
            }
            Console.WriteLine(fileName);
        }
    }
}