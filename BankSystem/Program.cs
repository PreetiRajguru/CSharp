using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Application");
            BankApplication user = new BankApplication();
            user.UserDetails();

            AccessMembers user1 = new AccessMembers();
            user1.AddBalance(5000);
            user1.CheckBalance();
            user1.MoneyDeposit(500);
            user1.MoneyWithdraw(8000);
            user1.MoneyWithdraw(800);
            user1.CheckBalance();
            Console.ReadKey(); 
        }
    }
}
