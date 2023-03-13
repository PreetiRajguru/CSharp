using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static FilePercent.ConstantMessages;

namespace FileUploader
{
    class Program 
    {
        delegate void PercentCalculator(long receivedBytes, long fileSize);
        static async Task Main()
        {
            //accepting source file to upload
            Console.Write(sourceInput);
            string sourceFilePath = Console.ReadLine();
            while (!File.Exists(sourceFilePath))
            {
                Console.Write(sourceNotExist);
                sourceFilePath = Console.ReadLine();
            }

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

            //creating fileinfo object of source file
            string sourceFileName = Path.GetFileName(sourceFilePath);

            //destination file path
            string destinationFilePath = Path.Combine(destinationFolder, sourceFileName);

            if (File.Exists(destinationFilePath))
            {
                Console.WriteLine(fileExists);
                Console.ReadKey();
                return;
            }

            //stopwatch to measure elapsed time
            Stopwatch stopwatch = Stopwatch.StartNew();

            //copying file asynchronously and displaying upload percent
            await FileUpload(sourceFilePath, destinationFilePath, (receivedBytes, fileSize) =>
            {
                double percentage = (double)receivedBytes / fileSize * 100;
                Console.WriteLine($"File Uploading ...{percentage:F2}%");
            });

            //displaying total elapsed time
            stopwatch.Stop();
            Console.WriteLine(partitionString);
            Console.WriteLine($"File Uploading Completed in {stopwatch.Elapsed.TotalSeconds:F2} Seconds.");
            Console.ReadKey();
        }
        static async Task FileUpload(string sourceFilePath, string destinationFilePath, PercentCalculator percent)
        {
            using (FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream destinationMemoryStream = new MemoryStream())
                {
                    long receivedBytes = 0;
                    long fileSize = sourceFileStream.Length;
                    //specified buffer size 4 KB = 4096 bytes
                    byte[] buffer = new byte[4096];
                    int transmittedBytes;

                    //reading file in blocks of 4 KB
                    while ((transmittedBytes = await sourceFileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        //writing file in blocks of 4 KB to memory stream
                        await destinationMemoryStream.WriteAsync(buffer, 0, transmittedBytes);
                        receivedBytes += transmittedBytes;
                        percent(receivedBytes, fileSize);
                    }

                    //writing memory stream to destination file
                    using (FileStream destinationFileStream = new FileStream(destinationFilePath, FileMode.CreateNew, FileAccess.Write))
                    {
                        await destinationMemoryStream.CopyToAsync(destinationFileStream);
                    }
                }
            }
        }
    }
}