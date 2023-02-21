using System;
using System.Linq;

namespace StringManipluations
{
    public class RemoveDuplicateChar
    {
        public void OnlyFirstOccurance()
        {
            Console.Write("Enter a string to remove duplicate characters and keep only the first occurance in the string : ");
            string name = Console.ReadLine().ToLower();

            string newString = String.Empty;
            string duplicates = String.Empty;
            foreach(char ch in name)
            {
                if(!newString.Contains(ch))
                {
                    newString += ch;
                }
                else
                {
                    duplicates += ch;
                }
            }

            Console.WriteLine("Removing the duplicates in the string : {0}", newString);
            Console.WriteLine("Duplicates in the string are : {0}", duplicates);
        }
    }
}
