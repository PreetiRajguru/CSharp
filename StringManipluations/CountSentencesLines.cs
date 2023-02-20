using System;

namespace StringManipluations
{
    public class CountSentencesLines
    {
        public void CountingSentence()
        {
            Console.WriteLine("Enter a paragraph of strings for counting sentences within it : ");
            string paragraph1 = Console.ReadLine();

            //splitting into array of sentences with ending punctuations and removing empty entries from the array
            string[] sentences = paragraph1.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            //sentences array size gives total number of sentences
            int totalsentences = sentences.Length;
            Console.WriteLine("Number of sentences in the paragraph are : {0} ", totalsentences);
        }

        public void CountingLines()
        {
            Console.WriteLine("Example of counting lines ...");
            string paragraph2 = "This is an example for counting lines. \n This is the next line. ";

            int linesCount = 1;
            for (int i = 0; i < paragraph2.Length; i++)
            {
                if (paragraph2[i] == '\n')
                {
                    linesCount++;
                }
            }
            Console.WriteLine("Total number of lines in the paragraph are : {0}", linesCount);
        }
    }
}
