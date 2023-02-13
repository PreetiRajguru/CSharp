using System; 

namespace BankSystem
{

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
        public double AddBalance(double amount)
        {
            balance = balance + amount;
            Console.WriteLine("After your first transaction your Initial Balance in the account is " + balance);
            return balance;
        }
        public double MoneyDeposit(double amount)
        {
            balance = balance + amount;
            Console.WriteLine("Your updated balance after deposit is " + balance);
            return balance;
        }
    }

    //internal class
    internal class AccessMembers : BankAccessSpecifier
    {
        public double MoneyWithdraw(double amount)
        {
            if (balance < amount)
            {
                Console.WriteLine("Sorry ! "+userName+" You dont have enough balance.");
            }
            else
            {
                balance = balance - amount;
            }
            Console.WriteLine("Your updated balance after withdrawal is " + balance);
            return balance;
        }

        //parent class protected method 
        internal void CheckBalance()
        {
            Console.WriteLine("Total balance in your account is " + balance);
        }
    }
}
