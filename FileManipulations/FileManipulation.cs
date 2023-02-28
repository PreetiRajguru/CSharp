using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManipulations
{
    internal class FileManipulation
    {
        public void FileOperations()
        {
            //accept directory path
            string selectedFolder = string.Empty;
            try
            {
                Console.Write("Enter the directory path : ");
                selectedFolder = Console.ReadLine();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory not found: " + e.Message);
            }
            while (!(Path.IsPathRooted(selectedFolder)))
            {
                Console.WriteLine("Invalid file path.");
                Console.Write("Please enter again : ");
                selectedFolder = Console.ReadLine();
            }

            //displaying total files in the directory to select for writing
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Files in the directory are : ");
            List<string> list = new List<string>();
            string[] fileArray = Directory.GetFiles(selectedFolder);
            for (int i = 0; i < fileArray.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + Path.GetFileName(fileArray[i]));
                list.Add(fileArray[i]);
            }

            //accepting user input for selecting the number of file to read
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.Write("Which file do you wish to read? ");
            int fileNumToRead;
            while (!int.TryParse(Console.ReadLine(), out fileNumToRead) || (fileNumToRead < 1 || fileNumToRead > list.Count))
            {
                Console.Write("Please enter valid input : ");
            }

            //finding the file name in the list
            string readFileName = string.Empty;
            string readFilePath = string.Empty;
            
            
                readFileName = list[fileNumToRead - 1];
                readFilePath = Path.Combine(selectedFolder, readFileName);
            
            

            //opening selected file for read
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
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        Console.WriteLine($"The data inside {Path.GetFileName(selectedFilePath)} is : ");
                        text = streamReader.ReadToEnd();
                    }
                    Console.WriteLine(text);
                    Console.WriteLine("Data is read from the file successfully.");

                    //replacing word in file
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Enter string to replace : ");
                    string searchString = Console.ReadLine();
                    Console.WriteLine("Enter replacement string : ");
                    string replacementString = Console.ReadLine();

                    string text2 = File.ReadAllText(selectedFilePath);
                    text2 = text2.Replace(searchString, replacementString);
                    File.WriteAllText(selectedFilePath, text2);
                    string text1 = File.ReadAllText(selectedFilePath);
                    Console.WriteLine("The file contents after word replacement are : ");
                    Console.WriteLine(text1);

                    //reading last line of selected file
                    Console.WriteLine();
                    Console.Write("Last Line is : ");
                    var last = File.ReadLines(selectedFilePath).Last();
                    Console.WriteLine(last);

                    //displaying last line with name file
                    Console.WriteLine($"The last line in {Path.GetFileName(selectedFilePath)} is {last}");
                    fileStream.Close();
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("File not found: " + ex.Message);
                }
                catch (UnauthorizedAccessException except)
                {
                    Console.WriteLine("Unauthorized access to file : " + except.Message);
                }
                //creating file with user name and locn as input
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter Location where you want to create file : ");
                string locn = Console.ReadLine();
                Console.WriteLine("file name for new file with \\ and extension : ");
                string name = Console.ReadLine();
                string newFileName = String.Concat(locn, name);

                FileStream fileStream1 = new FileStream(newFileName, FileMode.Create);
                fileStream1.Close();
                //copying the source file contents to the destination file
                using (FileStream originalFileStream = File.OpenRead(selectedFilePath))
                {
                    using (FileStream outputFileStream = File.OpenWrite(newFileName))
                    {
                        originalFileStream.CopyTo(outputFileStream);
                    }
                }
                Console.WriteLine($"File has been created and the Path is {locn}");
                Console.WriteLine("Copied contents of " + Path.GetFileName(selectedFilePath) + " to " + Path.GetFileName(newFileName));

                fileStream1.Close();

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Cannot read {Path.GetFileName(selectedFilePath)}");
            }
        }
    }
}