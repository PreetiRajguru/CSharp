﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //query the list of numbers to get only the even numbers
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;

            //display the even numbers
            Console.WriteLine("Even numbers:");
            foreach (var n in evenNumbers)
            {
                Console.WriteLine(n);
            }

            //query the list of numbers to get the sum of all the odd numbers
            var sumOfOddNumbers = (from n in numbers
                                   where n % 2 == 1
                                   select n).Sum();

            //display the sum of the odd numbers
            Console.WriteLine("Sum of odd numbers: {0}", sumOfOddNumbers);
            Console.ReadKey();
        }
    }
}
