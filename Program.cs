using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Application");
            BankApplication user = new BankApplication();
            user.UserDetails();
            Console.ReadLine();
        }
    }
}
