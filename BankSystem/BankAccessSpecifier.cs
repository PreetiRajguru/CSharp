using System; 

namespace BankSystem
{
    public class InvalidBalanceException : Exception
    {
      public InvalidBalanceException(String message) : base(message)
        {

        }
    }
    public class InvalidCapacityException : Exception
    {
        public InvalidCapacityException(String message) : base(message)
        {

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
            if(amount > 100000)
            {
                throw new InvalidCapacityException("Amount too Large !");
            }
            balance += amount;
            Console.WriteLine("Your updated balance after deposit is " + balance);
            return balance;
        }
    }

    //internal class
    internal class AccessMembers : BankAccessSpecifier
    {
        public double MoneyWithdraw(double amount)
        {
            if(amount > 50000)
            {
                throw new InvalidBalanceException("Sorry, you dont have enough balance.");
            }
            else
            {
                balance -= amount;
            }

            /*if (balance < amount)
            {
                throw new InvalidBalanceException("Sorry, you dont have enough balance.");
            }
            else
            {
                balance -= amount;
            }*/
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
