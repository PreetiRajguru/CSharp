//Bank Application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSystem
{
    internal class BankApplication
    {
        public void UserDetails()
        {
            Console.WriteLine("Personal Details Form");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter the following details");

            //accept first name
            Console.Write("First Name : ");
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter first name : ");
                    firstName = Console.ReadLine();
                } while (string.IsNullOrEmpty(firstName));
            }

            //accept last name
            Console.Write("Last Name : ");
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter last name : ");
                    lastName = Console.ReadLine();
                } while (string.IsNullOrEmpty(lastName));
            }

            //accept gender in F or M
            Console.Write("Gender(F/M) : ");
            char gender = Console.ReadLine().ToUpper()[0];
            if (gender != 'F' && gender != 'M')
            {
                do
                {
                    Console.Write("Invalid Gender! Please enter gender again: ");
                    gender = Console.ReadLine().ToUpper()[0];
                } while (gender != 'F' && gender != 'M');
            }

            //accept email
            Console.Write("Email : ");
            String email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            /*&& string.IsNullOrWhiteSpace(email)*/
            if (!match.Success)
            {
                Console.WriteLine(email + " is inValid Email Address");
                Console.Write("Please enter corrrect email : ");
                email = Console.ReadLine();
            }

            //accept phone number
            Console.Write("Phone Number : ");
            long phoneNumber = long.Parse(Console.ReadLine());
            long checkcount = phoneNumber.ToString().Length;
            if (checkcount == 0 || checkcount < 10)
            {
                    Console.Write("Invalid phone number. Please enter phone number again: ");
                    phoneNumber = long.Parse(Console.ReadLine());        
            }

            //marital status
            Console.Write("Marital Status(Y/N) : ");
            string maritalStatus = Console.ReadLine();

            if ((maritalStatus != "Y" && maritalStatus != "N") && (maritalStatus != "y" && maritalStatus != "n"))
            {
                Console.Write("Invalid status! Please enter again: ");
                maritalStatus = Console.ReadLine();

                if (maritalStatus == "Y" || maritalStatus == "y")
                {
                    Console.Write("Spouse Name : ");
                    string spouseName = Console.ReadLine();

                    Console.Write("Do You Have Children(Y/N) : ");
                    string children = Console.ReadLine();

                    if (children == "Y")
                    {
                        Console.Write("Number Of Children : ");
                        int totalchildren = Convert.ToInt32(Console.ReadLine());
                        string[] childrenNames = new string[totalchildren];
                        for (int i = 0; i < childrenNames.Count(); i++)
                        {
                            Console.Write("Enter {0} child name : ", i + 1);
                            childrenNames[i] = Console.ReadLine();
                        }
                    }
                }
            }
            else
            {
                if (maritalStatus == "Y" || maritalStatus == "y")
                {
                    Console.Write("Spouse Name : ");
                    string spouseName = Console.ReadLine();

                    Console.Write("Do You Have Children(Y/N) : ");
                    string children = Console.ReadLine();

                    if (children == "Y" || children == "y")
                    {
                        Console.Write("Number Of Children : ");
                        int totalchildren = Convert.ToInt32(Console.ReadLine());
                        string[] childrenNames = new string[totalchildren];
                        for (int i = 0; i < childrenNames.Count(); i++)
                        {
                            Console.Write("Enter {0} child name : ", i + 1);
                            childrenNames[i] = Console.ReadLine();
                        }
                    }
                }
            }

            //bank account type
            Console.Write("Bank Account Type (Current/Savings ?) : ");
            string accountType = Console.ReadLine();
            if (string.IsNullOrEmpty(accountType))
            {
                Console.Write("Invalid Input. Please enter bank account type : ");
                accountType = Console.ReadLine();
            }
            if ((accountType != "current" && accountType != "savings") && (accountType != "Current" && accountType != "Savings"))
            {
                Console.Write("Invalid Input. Please enter bank account type : ");
                accountType = Console.ReadLine();
            }

            //pan number
            Console.Write("PAN Number : ");
            long panNumber = long.Parse(Console.ReadLine());
            long totaldigits = panNumber.ToString().Length;
            if (totaldigits == 0 || totaldigits < 10)
            {
                Console.Write("Invalid pan number. Please enter pan number again: ");
                panNumber = long.Parse(Console.ReadLine());
            }

            //nominee
            Console.Write("Add Nominee ?(Y/N) : ");
            string nominee = Console.ReadLine();
            if (string.IsNullOrEmpty(nominee))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter correct value : ");
                    nominee = Console.ReadLine();
                } while (string.IsNullOrEmpty(nominee));
            }
            if (nominee == "Y" || nominee == "y")
            {
                Console.Write("Nominee Name : ");
                string nomineeName = Console.ReadLine();
                if (string.IsNullOrEmpty(nomineeName))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter correct value : ");
                        nomineeName = Console.ReadLine();
                    } while (string.IsNullOrEmpty(nomineeName));
                }
            }

            //permanent address
            Console.Write("Permanent Address : ");
            string permanentAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(permanentAddress))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter permanent address : ");
                    permanentAddress = Console.ReadLine();
                } while (string.IsNullOrEmpty(permanentAddress));
            }

            //communication address
            Console.Write("Communication Address Same As Permanent Address (Y/N)) : ");
            string sameAddress = Console.ReadLine();
            string communicationAddress;
            if (sameAddress == "N" || sameAddress == "n")
            {
                Console.Write("Communication Address : ");
                communicationAddress = Console.ReadLine();
                if (string.IsNullOrEmpty(communicationAddress))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter communication address : ");
                        communicationAddress = Console.ReadLine();
                    } while (string.IsNullOrEmpty(communicationAddress));
                }
            }
            else
            {
                communicationAddress = permanentAddress;
            }

            //credit card 
            Console.Write("Do You Want Credit Card ? (Y/N) : ");
            string creditCard = Console.ReadLine();
            if (creditCard == "Y" || creditCard == "y")
            {
                Console.Write("Salary : ");
                int salary = Convert.ToInt32(Console.ReadLine());
                if (salary < 1000)
                {
                    Console.WriteLine("Sorry! You Have Low Income");
                }
            }
            Console.Write("Press Y To Exit : ");
            string finalexit = Console.ReadLine();
            if (finalexit == "Y" || finalexit == "y")
            {
                //display all data
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Congratulations! Your Bank Account Is Created Successfully.");
                Console.WriteLine("Your personal details are as follows: ");
                Console.WriteLine("First Name is: " + firstName);
                Console.WriteLine("Last Name is: " + lastName);
                Console.WriteLine("Gender : " + gender);
                Console.WriteLine("Email : " + email);
                Console.WriteLine("Phone Number : " + phoneNumber);
                Console.WriteLine("Marital Status : " + maritalStatus);
                Console.WriteLine("Bank Account Type : " + accountType);
                Console.WriteLine("Pan Number : " + panNumber);
                Console.WriteLine("Permanent Address : " + permanentAddress);
                Console.WriteLine("Communication Address : " + communicationAddress);
                Random randomBankAccountNumber = new Random();
                Console.WriteLine("Your Bank Account Number Is: " + randomBankAccountNumber.Next(10000000, 1000000000));
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Press Y To Create Bank Account : ");
                Console.ReadKey();
            }
        }
    }
}