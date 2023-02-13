using System;

namespace AccessSpecifierExample
{
    //public class 
    public class IncubXperts
    {
        public IncubXperts()
        {
          
        }

        // private , protected , public property
        private double profit = 100000;
        protected int employees = 150;
        public int clients = 6;

        // private method
        private void FinancialManager()
        {
            Console.WriteLine("Manages Finances");
            Console.WriteLine("Determines the profit for the organization = " + profit);
        }

        // protected method
        protected void Employees()
        {
            Console.WriteLine("Employees work for the organization");
        }

        // public method
        public void Clients()
        {
            Console.WriteLine("Clients are the guests of the organization");
        }
    }
    // internal class
    internal class Interns : IncubXperts
    {
        public void InternsTraining()
        {
            Console.WriteLine("Interns have some employee access rights");
            Console.Write("Interns are also a part of organization and add to the total count of ");
            //accessing protected property
            Console.WriteLine(employees);

        }

    }

}