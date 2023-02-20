using System;
using System.Linq;

namespace StringManipluations
{
    internal class RemoveDuplicateChar
    {
        public void OnlyFirstOccurance()
        {
            Console.Write("Enter a string to remove duplicate characters and keep only the first occurance in the string : ");
            string name = Console.ReadLine().ToLower();

            string newString = " ";
            foreach(var ch in name)
            {
                if(!newString.Contains(ch))
                {
                    newString = newString + ch;
                }
            }

            Console.WriteLine("Removing the duplicates in the string : {0}", newString);
        }
    }
}
