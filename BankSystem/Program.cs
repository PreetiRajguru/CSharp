using System;
using System.Runtime.Remoting.Services;
using System.Security.Policy;

namespace BankSystem
{
    public class Program : BankAccessSpecifier
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


            if (atmPin.Equals(1234))
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
                                Console.WriteLine("Enter \"1\" to withdraw or enter \"2\" to terminate : ");
                                string inp = Console.ReadLine().ToUpper();
                                if (inp != "1" && inp != "2")
                                {
                                    do
                                    {
                                        Console.Write("Enter 1 to withdraw or 2 to cancel :");
                                        inp = Console.ReadLine().ToUpper();
                                    } while (inp != "1" && inp != "2");
                                }
                                switch (inp)
                                {
                                    case "1":
                                        Console.WriteLine("Enter amount to withdraw :");
                                        double amount = double.Parse(Console.ReadLine());
                                        if (amount >= 0)
                                        {
                                            user1.MoneyWithdraw(amount);
                                            CountWithdraw += amount;
                                            if (CountWithdraw > 50000)
                                            {
                                                user1.balance += amount;
                                                CountWithdraw += amount;
                                                throw new InvalidBalanceException();
                                            }
                                            user1.CheckBalance();
                                        }
                                        else
                                        {
                                            do
                                            {
                                                Console.WriteLine("Cannot accept negative number ");
                                                Console.WriteLine("Enter amount to withdraw again:");
                                                amount = double.Parse(Console.ReadLine());
                                            } while (amount < 0);
                                            user1.MoneyWithdraw(amount);
                                            CountWithdraw += amount;
                                            if (CountWithdraw > 50000)
                                            {
                                                user1.balance += amount;
                                                CountWithdraw += amount;
                                                throw new InvalidBalanceException();
                                            }
                                            user1.CheckBalance();
                                        }
                                        break;
                                    case "2":
                                        string cancel = Console.ReadLine().ToUpper();
                                        if (cancel == "2")
                                        {
                                            break;
                                        }
                                        break;
                                }
                            }
                            catch (InvalidBalanceException b)
                            {
                                Console.WriteLine($"Message: {b.Message}");
                            }
                            catch (InsufficientBalanceException a)
                            {
                                Console.WriteLine(a.Message);
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine("Enter amount you want to add in your account :");
                                double amountDeposit = double.Parse(Console.ReadLine());
                                if (amountDeposit >= 0)
                                {
                                    user1.MoneyDeposit(amountDeposit);
                                    CountDeposit += amountDeposit;
                                    if (CountDeposit > 100000)
                                    {
                                        user1.balance -= amountDeposit;
                                        CountDeposit -= amountDeposit;
                                        throw new InvalidCapacityException();
                                    }
                                    user1.CheckBalance();
                                }
                                else
                                {
                                    do
                                    {
                                        Console.WriteLine("Cannot accept negative number ");
                                        Console.WriteLine("Enter amount to deposit again:");
                                        amountDeposit = double.Parse(Console.ReadLine());
                                    } while (amountDeposit < 0);
                                    user1.MoneyDeposit(amountDeposit);
                                    CountDeposit += amountDeposit;
                                    if (CountDeposit > 100000)
                                    {
                                        user1.balance -= amountDeposit;
                                        CountDeposit -= amountDeposit;
                                        throw new InvalidCapacityException();
                                    }
                                    user1.CheckBalance();
                                }
                            }
                            catch (InvalidCapacityException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 4:
                            Console.WriteLine("\n Thankyou for banking with us...");
                            Console.ReadKey();
                            return;
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
