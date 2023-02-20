using System;

namespace StringManipulations
{
    public class ReverseWords
    {
        public void ReverseWordsInString()
        {
            Console.Write("Enter a simple string to reverse words in the string : ");
            string originalString = Console.ReadLine();

            //splitting original string into words array with space character delimeter
            string[] words = originalString.Split(' ');

            //traversing through words array
            for (int i = 0; i < words.Length; i++)
            {
                //converting words array to character array
                char[] alphabets = words[i].ToCharArray();
                //reversing character array 
                Array.Reverse(alphabets);
                //converting character array to words array
                words[i] = new string(alphabets);
            }

            //joining the character array with space as delimeter into a string
            string reversedString = string.Join(" ", words);
            Console.WriteLine(reversedString);
        }
    }
}
