using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StringManipulations
{
    internal class StringMethods
    {
        public void StringMethodsUse()
        {
            Console.WriteLine("Enter three strings ...");

            //accepting and creating string
            Console.Write("Enter first string : ");
            string firstString = Console.ReadLine();
            Console.Write("Enter second string : ");
            string secondString = Console.ReadLine();
            Console.Write("Enter third string : ");
            string thirdString = Console.ReadLine();

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");


            //length property and displaying using string interpolation
            Console.WriteLine("Length of first string : {0}", firstString.Length);

            //concatenation method
            string fourthString = String.Concat(firstString, secondString);
            Console.WriteLine("First string and second string concatenated : {0}", fourthString);

            //toUpper and toLower method
            string fifthString = firstString.ToUpper();
            string sixthString = thirdString.ToLower();
            Console.WriteLine("First string in upper case: {0}", fifthString);
            Console.WriteLine("Third string in lower case: {0}", sixthString);

            //compare two strings method
            Boolean result1 = firstString.Equals(secondString);
            Console.WriteLine("First string and second string are equal ? : " + result1);

            //contains method
            Boolean result2 = secondString.Contains("a");
            Console.WriteLine("Second string contains 'a' ? : " + result2);

            //subString method
            string subString = firstString.Substring(2);
            Console.WriteLine("Substring of first string starting from index 2 is : {0}", subString);

            //trim method
            string seventhString = "     Whitespaces     ";
            Console.WriteLine("String without using trim method : {0}", seventhString);
            Console.WriteLine("String with using trim method : {0}", seventhString.Trim());

            //replace method
            string eightString = thirdString.Replace("a", "b");
            Console.WriteLine("Replacing 'a' with 'b' : {0}", eightString);

            //indexOf method
            int index = secondString.IndexOf("a");
            Console.WriteLine("Index of 'a' in second string is : " + index);

            //format and toString method
            Console.WriteLine("Enter any name : ");
            string nameString = Console.ReadLine();
            Console.WriteLine("Enter age : ");
            int age = int.Parse(Console.ReadLine());
            string personInfo = string.Format("{0} is {1} years old.", nameString, age.ToString());
            Console.WriteLine(personInfo);

            //toCharArray method
            Console.WriteLine("Enter a sentence : ");
            string sentence = Console.ReadLine();
            char[] charArr = sentence.ToCharArray();
            foreach (char ch in charArr)
            {
                Console.WriteLine(ch);
            }

            //split method
            string[] words = sentence.Split(' ');
            Console.WriteLine("Words in above entered string are : ");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            //empty property
            Console.WriteLine("Enter a string : ");
            string emptyCheck = Console.ReadLine();
            if (emptyCheck != string.Empty)
            {
                Console.WriteLine("String is not empty.");
            }
            else
            {
                Console.WriteLine("String is empty.");
            }

            //endsWith method
            Boolean result3 = firstString.EndsWith("e");
            Console.WriteLine("First string ends with 'e' ? : {0}", result3);

            //startsWith method
            Boolean result4 = firstString.StartsWith("h");
            Console.WriteLine("First string starts with 'h' ? : {0}", result3);

            //remove method
            Console.Write("Enter a string : ");
            string ninthString = Console.ReadLine();
            string tenthString = ninthString.Remove(2);
            Console.WriteLine("Removing characters from index 2 : {0}", tenthString);

            //lastIndexOf method
            Console.Write("Enter a string : ");
            string eleventhString = Console.ReadLine();
            int index1 = eleventhString.LastIndexOf("a");
            Console.WriteLine("Last occurance of character 'a' is at index : {0}", index1);

            //isNullOrEmpty
            bool b1 = string.IsNullOrEmpty(firstString);
            Console.WriteLine("Is first string null or empty ? : {0}", b1);

            //isNullOrWhiteSpace
            bool b2 = string.IsNullOrWhiteSpace(secondString);
            Console.WriteLine("Is second string null or empty ? : {0}", b2);

            //copy method
            string newString = string.Copy(firstString);
            Console.WriteLine("Copying first string into new string : {0}", newString);

            //clone method
            string cloneString = (String)secondString.Clone();
            Console.WriteLine("Cloning second string into another string : {0}", cloneString);
        }
    }
}
