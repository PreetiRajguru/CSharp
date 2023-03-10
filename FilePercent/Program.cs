using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader
{
    class Program
    {
        static async Task Main()
        {
            //accepting source file to upload
            Console.Write("Enter the source file path to upload : ");
            string sourceFilePath = Console.ReadLine();
            while (!File.Exists(sourceFilePath))
            {
                Console.Write("Source file does not exist. Please enter again : ");
                sourceFilePath = Console.ReadLine();
            }

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

            //creating fileinfo object of source file
            string sourceFileName = Path.GetFileName(sourceFilePath);

            //destination file path
            string destinationFilePath = Path.Combine(destinationFolder, sourceFileName);

            if (File.Exists(destinationFilePath))
            {
                Console.WriteLine("Destination file already exists.");
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
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"File Uploading Completed in {stopwatch.Elapsed.TotalSeconds:F2} Seconds.");
            Console.ReadKey();
        }

        static async Task FileUpload(string sourceFilePath, string destinationFilePath, Action<long, long> percentCalculator)
        {
            using (FileStream sourceFileUpload = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream destinationFileUpload = new FileStream(destinationFilePath, FileMode.CreateNew, FileAccess.Write))
                {
                    long receivedBytes = 0;
                    long fileSize = sourceFileUpload.Length;
                    //specified buffer size 4 KB = 4096 bytes
                    byte[] buffer = new byte[4096];
                    int transmittedBytes;

                    //reading file in blocks of 4 KB
                    while ((transmittedBytes = await sourceFileUpload.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        //writing file in blocks of 4 KB
                        await destinationFileUpload.WriteAsync(buffer, 0, transmittedBytes);
                        receivedBytes += transmittedBytes;
                        percentCalculator(receivedBytes, fileSize);
                    }
                }
            }
        }
    }
}