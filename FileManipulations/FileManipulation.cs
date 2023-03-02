using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FileManipulations
{
    internal class FileManipulation
    {
        public void FileOperations()
        {
            //accept directory path
            string selectedFolder;
            Console.Write("Enter the directory path : ");
            selectedFolder = Console.ReadLine();

            while (!(Path.IsPathRooted(selectedFolder)))
            {
                Console.WriteLine("Invalid file path.");
                Console.Write("Please enter again : ");
                selectedFolder = Console.ReadLine();
            }

            //displaying total files in the directory to select for writing
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Files in the directory are : ");
            List<string> filesList = new List<string>();
            try
            {
                string[] fileArray = Directory.GetFiles(selectedFolder);
                for (int i = 0; i < fileArray.Length; i++)
                {
                    Console.WriteLine(i + 1 + ") " + Path.GetFileName(fileArray[i]));
                    filesList.Add(fileArray[i]);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found...");
            }

            //accepting user input for selecting the number of file to read
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.Write("Enter the number of file that you wish to read : ");
            int fileNumToRead;
            while (!int.TryParse(Console.ReadLine(), out fileNumToRead) || (fileNumToRead < 1 || fileNumToRead > filesList.Count))
            {
                Console.Write("Please enter valid input : ");
            }

            //finding the file name in the list
            string readFileName;
            string readFilePath;
            readFileName = filesList[fileNumToRead - 1];
            readFilePath = Path.Combine(selectedFolder, readFileName);
            string selectedFilePath = readFilePath;
            string extension = Path.GetExtension(readFilePath);

            if (extension == ".txt")
            {
                try
                {
                    //read all text in selected file
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                    string text;
                    var fileStream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read);
                    if (!File.Exists(selectedFilePath))
                    {
                        throw new FileNotFoundException();
                    }
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        Console.WriteLine($"The data inside {Path.GetFileName(selectedFilePath)} is : ");
                        text = streamReader.ReadToEnd();
                    }
                    Console.WriteLine(text);
                    Console.WriteLine("Data is read from the file successfully.");

                    //replacing word in file
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Enter word to replace : ");
                    string searchString = Console.ReadLine();
                    string replacementString = String.Empty;


                    if(!text.Contains(searchString))
                    {
                        Console.WriteLine("Word not found.");
                    }
                    else
                    {
                        Console.WriteLine("Enter replacement string : ");
                        replacementString = Console.ReadLine();
                        string data = File.ReadAllText(selectedFilePath);
                        data = data.Replace(searchString, replacementString);
                        File.WriteAllText(selectedFilePath, data);
                        string newData = File.ReadAllText(selectedFilePath);
                        Console.WriteLine("The file contents after word replacement are : ");
                        Console.WriteLine(newData);
                    }

                    //reading last line of selected file
                    Console.WriteLine();
                    string lastLine = File.ReadLines(selectedFilePath).Last();

                    //displaying last line with name file
                    Console.WriteLine($"The last line in {Path.GetFileName(selectedFilePath)} is {lastLine}");
                    fileStream.Close();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found... ");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Unauthorized access to file...");
                }

                //creating file with user defined name and locn as input
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter Location where you want to create file : ");
                string fileLocation = Console.ReadLine();

                if (!(Directory.Exists(fileLocation)))
                {
                    Directory.CreateDirectory(fileLocation);
                    Console.WriteLine("Destination Folder Created" + fileLocation);
                }

                Console.WriteLine("Enter name for file : ");
                string fileName = Console.ReadLine();
                
               string filePathCreated =  CreatingFilePath(fileLocation,fileName);
                while (File.Exists(filePathCreated))
                {
                    Console.Write("File with this name already exists.");
                    Console.Write("Enter new file name :");
                    fileName = Console.ReadLine();
                    CreatingFilePath(fileLocation, fileName);              
                }
                using (StreamWriter sw = File.CreateText(filePathCreated))
                {
                    Console.WriteLine("File created successfully!");
                }

                FileStream newFile = new FileStream(filePathCreated, FileMode.Create);
                newFile.Close();

                //copying the source file contents to the destination file
                using (FileStream originalFileStream = File.OpenRead(selectedFilePath))
                {
                    using (FileStream outputFileStream = File.OpenWrite(filePathCreated))
                    {
                        originalFileStream.CopyTo(outputFileStream);
                    }
                }
                Console.WriteLine($"File has been created and the Path is {fileLocation}");
                Console.WriteLine("Copied contents of " + Path.GetFileName(selectedFilePath) + " to " + Path.GetFileName(filePathCreated));
                newFile.Close();

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Cannot read {Path.GetFileName(selectedFilePath)}");
                Console.ReadKey();
            }
        }
        string CreatingFilePath(string fileLocation,string fileName)
        {
          return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileLocation, fileName);
        }
    }
}