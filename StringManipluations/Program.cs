using System;
using StringManipluations;

namespace StringManipulations
{
    internal class Program /*: CountSentencesLines*/
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("String Manipulation Programs...");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            /*StringMethods methodsObject = new StringMethods();
            methodsObject.StringMethodsUse();*/

            ReverseWords reverseString = new ReverseWords();
            reverseString.ReverseWordsInString();
            reverseString.ReverseWordsLogic();

            /*CountSentencesLines sentenceObject = new CountSentencesLines();
            sentenceObject.CountingSentence();*/

            /*CountSentencesLines lineObject = new CountSentencesLines();
            lineObject.CountingLines();

            lineObject.SpecialCharacterLength();*/

            /*    RemoveDuplicateChar nameObject = new RemoveDuplicateChar();
                nameObject.OnlyFirstOccurance();*/

            /*LargestCommonPrefix longest = new LargestCommonPrefix();
            longest.LongestCommonPrefix();*/

            Console.ReadKey();

        }
    }
}
