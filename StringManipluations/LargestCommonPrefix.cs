using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringManipulations;

namespace StringManipluations
{
    public class LargestCommonPrefix 
    {
        public void LongestCommonPrefix()
        {
            //accepting string array
            Console.WriteLine("Enter strings array seperated by space : ");
            string[] words = Console.ReadLine().Split(' ');

            //storing length of array
            int n = words.Length;
            int i = 0;

            //finding the length of the shortest word in the words array
            int minLength = int.MinValue;
            for(i = 0; i < n; i++)
            {
                if (words[i].Length > minLength) 
                {
                    minLength = words[i].Length;
                }
            }

            //finding the longest common prefix
            int j = 0;
            for (j = 0; j < minLength; j++)
            {
                char currChar = words[0][j];
                for(i =1;i<n;i++)
                {
                    if (words[i][j] != currChar)
                    {
                        break;
                    }
                }
                if(i<n)
                {
                    break;
                }
            }

            //longest common prefix
            string longestCommonPrefix = words[0].Substring(0, j);

            //counting the number of occurrance
            int count = 0;
            for(i=0;i <n;i++)
            {
                if (words[i].StartsWith(longestCommonPrefix))
                {
                    count++;
                }
            }

            //output
            Console.WriteLine("The longest prefix found is : " + longestCommonPrefix);
            Console.WriteLine("The count of occurrance is " + count);
        }
    }
}