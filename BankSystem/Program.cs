using System;
using System.Runtime.Remoting.Services;

namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Application");
            /*BankApplication user = new BankApplication();
            user.UserDetails();*/

            AccessMembers user1 = new AccessMembers();
            int option, atmPin;          
            Console.Write("Enter Your ATM Pin (1234): ");
            atmPin = int.Parse(Console.ReadLine());


            if (atmPin == 1234)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Select one option : \n");
                    Console.WriteLine("1. Check Balance\n");
                    Console.WriteLine("2. Cash Withdrawal\n");
                    Console.WriteLine("3. Cash Deposit\n");
                    Console.WriteLine("4. Exit\n");
                    Console.WriteLine("--------------------------------------------------------\n\n");
                    Console.Write("Select option: ");
                    option = int.Parse(Console.ReadLine());
                    
                    switch (option)
                    {
                        case 1:
                            user1.CheckBalance();
                            break;
                        case 2:
                            try
                            {                             
                                Console.WriteLine("Enter \"continue\" to withdraw or enter \"Cancel\" to terminate : ");
                                string inp = Console.ReadLine().ToUpper();
                                if(inp != "CONTINUE" && inp != "CANCEL")
                                {
                                    do
                                    {
                                        Console.Write("Enter Continue or Cancel :");
                                        inp = Console.ReadLine().ToUpper();
                                    } while (inp != "CONTINUE" && inp != "CANCEL");
                                }
                                switch (inp)
                                {   
                                    case "CONTINUE":
                                        Console.WriteLine("Enter amount to withdraw :");
                                        double amount = double.Parse(Console.ReadLine());
                                        user1.MoneyWithdraw(amount); 
                                        break;
                                    case "CANCEL":
                                        string cancel = Console.ReadLine().ToUpper();
                                        if (cancel == "CANCEL")
                                        {
                                            break;
                                        }
                                        break;                                   
                                }
                            }
                            catch (InvalidBalanceException)
                            {
                                Console.WriteLine("Sorry ! You are exceeding your limit...");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter amount you want to add in your account :");
                            double amountDeposit = double.Parse(Console.ReadLine());
                            try
                            {
                                user1.MoneyDeposit(amountDeposit);
                            }
                            catch (InvalidCapacityException)
                            {
                                Console.WriteLine("Amount Too Large !");
                            }
                            break;
                        case 4:
                            Console.WriteLine("\n Thankyou for banking with us...");
                            break;
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey(); 
        }
    }
}
