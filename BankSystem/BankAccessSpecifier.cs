using System;

namespace BankSystem
{
    public class InvalidBalanceException : Exception
    {
        public override string Message
        {
            get
            {
                return "Sorry ! You are exceeding your limit...";
            }
        }
    }
    public class InsufficientBalanceException : Exception
    {
        public override string Message
        {
            get
            {
                return "Sorry ! You dont have enough balance...";
            }
        }
    }
    public class InvalidCapacityException : Exception
    {
        public override string Message
        {
            get
            {
                return "Amount Too Large !";
            }
        }
    }

    //public class specifier
    public class BankAccessSpecifier
    {
        //private , protected , public and internal access specifier for property
        public double balance;
        protected string userName = "Customer";
        //private int accountNumber = 1234567891;
        internal string location = "Pune";

        //protected access specifier for method
        protected void CheckBalance()
        {
            Console.WriteLine("Your Balance is " + balance);
        }

        //public access specifier for method
        public double MoneyDeposit(double amount)
        {
            if (amount > 100000)
            {
                throw new InvalidCapacityException();
            }
            else
            {
                balance += amount;
            }
            Console.WriteLine("Your updated balance after deposit is " + balance);
            return balance;
        }
    }

    //internal class
    internal class AccessMembers : BankAccessSpecifier
    {
        public double MoneyWithdraw(double amount)
        {
            if (amount > 50000)
            {
                throw new InvalidBalanceException();
            }
            else if (balance < amount)
            {
                throw new InsufficientBalanceException();
            }
            else
            {
                balance -= amount;
            }
            Console.WriteLine("Your updated balance after withdrawal is " + balance);
            return balance;
        }

        //parent class protected method 
        internal void CheckBalance()
        {
            Console.WriteLine("Your Balance is " + balance);
        }
    }
}
