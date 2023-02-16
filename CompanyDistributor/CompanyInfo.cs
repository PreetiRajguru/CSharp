using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDistributor
{
    public class CompanyInfo
    {
        public void AcceptCompanyDetails()
        {
            Console.WriteLine("How many companies ? ");
            int noOfCompanies = int.Parse(Console.ReadLine());
            CompanyDetails companydetails = new CompanyDetails();
            for (int i = 1; i <= noOfCompanies; i++)
            {
                companydetails.details();
            }
        }
    }
    public class CompanyDetails
    {
        public void details()
        {
            Console.WriteLine("Enter name of company : ");
            string companyName = Console.ReadLine();
        }

    }
}