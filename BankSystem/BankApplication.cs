//Bank Application

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankSystem
{
    public class BankApplication
    {
        public void UserDetails()
        {
            Console.WriteLine("Personal Details Form");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter the following details");

            //accept first name
            Console.Write("First Name : ");
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter first name : ");
                    firstName = Console.ReadLine();
                } while (string.IsNullOrEmpty(firstName.Trim()));
            }

            //accept last name
            Console.Write("Last Name : ");
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter last name : ");
                    lastName = Console.ReadLine();
                } while (string.IsNullOrEmpty(lastName.Trim()));
            }

            //accept gender in F or M
            Console.Write("Gender(F for Female/M for Male/O for Others) : ");
            string gender = Console.ReadLine().ToUpper();
            if (gender != "F" && gender != "M" && gender != "O")
            {
                do
                {
                    Console.Write("Invalid Gender! Please enter gender again: ");
                    gender = Console.ReadLine().ToUpper();
                } while (gender != "F" && gender != "M" && gender != "O");
            }

            //accept email
            Console.Write("Email : ");
            String email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                do
                {
                    Console.WriteLine(email + " is inValid Email Address");
                    Console.Write("Please enter corrrect email : ");
                    email = Console.ReadLine();
                    match = regex.Match(email);
                } while (!match.Success);
            }

            //accept phone number
            Console.Write("Phone Number : ");
            string phoneNumber = Console.ReadLine();
            Regex r = new Regex(@"^[0-9]{10}$");
            Match match1 = r.Match(phoneNumber);
            if (!match1.Success)
            {
                do
                {
                    Console.Write("Invalid phone number. Please enter phone number again: ");
                    phoneNumber = Console.ReadLine();
                    match1 = r.Match(phoneNumber);
                } while (!match1.Success);
            }

            //marital status         
            Console.Write("Marital Status(Married/Unmarried) : ");
            string maritalStatus = Console.ReadLine().ToUpper();
            var maritalInfo = new MartialInfo();
            if (maritalStatus != "MARRIED" && maritalStatus != "UNMARRIED")
            {
                maritalInfo = InvalidMaritalStatus();
            }
            else if (maritalStatus == "MARRIED")
            {
                maritalInfo = ValidMaritalStatus();
            }

            //bank account type
            Console.Write("Bank Account Type (Current/Savings ?) : ");
            string accountType = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(accountType))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter bank account type : ");
                    accountType = Console.ReadLine();
                } while (string.IsNullOrEmpty(accountType));
            }
            if (accountType != "CURRENT" && accountType != "SAVINGS")
            {
                do
                {
                    Console.Write("Invalid Input. Please enter bank account type : ");
                    accountType = Console.ReadLine();
                } while (accountType != "CURRENT" && accountType != "SAVINGS");           
            }

            //pan number
            Console.Write("PAN Number : ");
            string panNumber = Console.ReadLine();
            Regex re = new Regex("^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$");
            Match matchpan = re.Match(panNumber);
            if (!matchpan.Success)
            {
                do
                {
                    Console.Write("Invalid pan number. Please enter pan number again: ");
                    panNumber = Console.ReadLine();
                    matchpan = re.Match(panNumber);
                } while (!matchpan.Success);

            }

            //nominee
            Console.Write("Add Nominee ?(Y/N) : ");
            string nominee = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(nominee.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter correct value : ");
                    nominee = Console.ReadLine();
                } while (string.IsNullOrEmpty(nominee.Trim()));
            }
            
            string nomineeName = "";
            if (nominee == "Y")
            {
                nomineeName = NomineeNamePresent();
            }

            //permanent address
            Console.Write("Permanent Address : ");
            string permanentAddress = Console.ReadLine();
            if (string.IsNullOrEmpty(permanentAddress.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter permanent address : ");
                    permanentAddress = Console.ReadLine();
                } while (string.IsNullOrEmpty(permanentAddress.Trim()));
            }

            //communication address
            Console.Write("Communication Address Same As Permanent Address (Y/N)) : ");
            string sameAddress = Console.ReadLine().ToUpper();
            string communicationAddress;
            if (sameAddress == "N")
            {
                Console.Write("Communication Address : ");
                communicationAddress = Console.ReadLine();
                if (string.IsNullOrEmpty(communicationAddress.Trim()))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter communication address : ");
                        communicationAddress = Console.ReadLine();
                    } while (string.IsNullOrEmpty(communicationAddress.Trim()));
                }
            }
            else
            {
                communicationAddress = permanentAddress;
            }

            //credit card 
            Console.Write("Do You Want Credit Card ? (Y/N) : ");
            string creditCard = Console.ReadLine().ToUpper();
            if (creditCard != "Y")
            {
                do
                {
                    Console.WriteLine("Invalid input. Please enter again : ");
                    creditCard = Console.ReadLine().ToUpper();
                } while (creditCard != "Y");               
            }
            else
            {
                Console.Write("Salary : ");
                int salary = Convert.ToInt32(Console.ReadLine());
                if (salary < 5000)
                {
                    Console.WriteLine("Sorry! You Have Low Income");
                }
                else
                {
                    Console.WriteLine("Credit card request approved");
                }
            }

            Console.Write("Press Y To Create Bank Acoount : ");
            string finalExit = Console.ReadLine().ToUpper();

            if (finalExit == "Y")
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
                if (maritalStatus == "MARRIED")
                {
                    DisplayMartialInfo(maritalInfo.spouseName, maritalInfo.children, maritalInfo.totalchildren, maritalInfo.childrenNames);
                }
                Console.WriteLine("Bank Account Type : " + accountType);
                Console.WriteLine("Pan Number : " + panNumber);
                Console.WriteLine("Permanent Address : " + permanentAddress);
                Console.WriteLine("Communication Address : " + communicationAddress);
                if (nominee == "Y")
                {
                    Console.WriteLine("Nominee Name : " + nomineeName);
                }
                Random randomCreditCardNumber = new Random();
                if (creditCard == "Y")
                {
                    Console.WriteLine("Credit Card Number : " + randomCreditCardNumber.Next(1000000000, 1000000000));

                }
                Random randomBankAccountNumber = new Random();
                Console.WriteLine("Your Bank Account Number Is: " + randomBankAccountNumber.Next(10000000, 1000000000));
                Console.WriteLine("---  -----------------------------------------------------------------------------------");
                //Console.ReadKey();
            }
            else
            {
                Console.Write("Please Press Y To Create Bank Account : ");
                // Console.ReadKey();
            }

        }
        public string NomineeNamePresent()
        {
            Console.Write("Nominee Name : ");
            string nomineeName = Console.ReadLine();
            if (string.IsNullOrEmpty(nomineeName.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter correct value : ");
                    nomineeName = Console.ReadLine();
                } while (string.IsNullOrEmpty(nomineeName.Trim()));
            }
            return nomineeName;
        }
        public MartialInfo ValidMaritalStatus()
        {
            Console.Write("Spouse Name : ");
            string spouseName = Console.ReadLine();

            Console.Write("Do You Have Children ? (Y/N) : ");
            string children = Console.ReadLine().ToUpper();

            int totalchildren = 0;
            string[] childrenNames = new string[0];
            if (children == "Y")
            {
                Console.Write("Number Of Children : ");
                totalchildren = Convert.ToInt32(Console.ReadLine());
                childrenNames = new string[totalchildren];
                for (int i = 0; i < childrenNames.Count(); i++)
                {
                    Console.Write("Enter {0} child name : ", i + 1);
                    childrenNames[i] = Console.ReadLine();
                }
            }
            var data = new MartialInfo();
            data.spouseName = spouseName;
            data.children = children;
            data.totalchildren = totalchildren;
            data.childrenNames = childrenNames;

            return data;
        }

        public MartialInfo InvalidMaritalStatus()
        {
            string maritalStatus;
            do
            {
                Console.Write("Invalid status! Please enter again: ");
                maritalStatus = Console.ReadLine().ToUpper();
            } while (maritalStatus != "MARRIED" && maritalStatus != "UNMARRIED");

            return ValidMaritalStatus();
        }
        public void DisplayMartialInfo(string spouseName, string children, int totalchildren, string[] childrenNames)
        {
            Console.WriteLine("Spouse Name: " + spouseName);
            Console.WriteLine("Children Name: " + children);
            Console.WriteLine("TotalChildren: " + totalchildren);
            for (int i = 0; i < childrenNames.Length; i++)
            {
                string res = childrenNames[i];
                Console.WriteLine("ChildrenNames: " + res);
            }
        }

    }
}
