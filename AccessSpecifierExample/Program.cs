using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSpecifierExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Real Life Example of Access Specifier w.r.t IncubXperts Organization");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine(""); 
            IncubXperts accessSpecifierExample = new IncubXperts();
            //accessing private member
            accessSpecifierExample.Profit = 8000;
            Console.WriteLine("Profit = "+accessSpecifierExample.Profit);
            //accessing public method
            accessSpecifierExample.Clients();

            Interns intern = new Interns();
            //accessing protected property
            intern.InternsTraining();
            Console.ReadKey();
        }
    }
}
