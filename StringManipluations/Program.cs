using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringManipluations;

namespace StringManipulations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("String Manipulation Programs...");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            /* StringMethods stringFileObject1 = new StringMethods();
             stringFileObject1.StringMethodsUse();*/

            /*ReverseWords stringFileObject2 = new ReverseWords();
            stringFileObject2.ReverseWordsInString();*/

            /*CountSentencesLines sentenceObject = new CountSentencesLines();
            sentenceObject.CountingSentence();

            CountSentencesLines lineObject = new CountSentencesLines();
            lineObject.CountingLines();*/

            /*RemoveDuplicateChar nameObject = new RemoveDuplicateChar();
            nameObject.OnlyFirstOccurance();*/

            LargestCommonPrefix longest = new LargestCommonPrefix();
            longest.LongestCommonPrefix();

            Console.ReadKey();

        }
    }
}
