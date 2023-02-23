using System;
using System.Collections.Generic;

namespace CompanyDistributor
{
    public class Program : Company
    {
        static void Main(string[] args)
        {
            //list for storing company, vehicle and distributors data
            List<Company> companies = new List<Company>();
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Distributor> distributors = new List<Distributor>();

            //company info
            Console.Write("How many companies details you want to enter? : ");
            int noOfCompanies;

            while (!int.TryParse(Console.ReadLine(), out noOfCompanies))
            {
                Console.Write("Please enter a valid numerical input : ");
            }

            for (int i = 1; i <= noOfCompanies; i++)
            {
                Company company = new Company();

                Console.Write("Enter {0} Company name : ", i);
                company.CompanyName = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(company.CompanyName.Trim()))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter again : ");
                        company.CompanyName = Console.ReadLine().ToUpper();
                    } while (string.IsNullOrEmpty(company.CompanyName.Trim()));
                }

                if (companies.Exists(c => c.CompanyName == company.CompanyName))
                {
                    Console.WriteLine("Company already exists.");
                    Console.Write("Please enter another name again : ");
                    company.CompanyName = Console.ReadLine().ToUpper();

                    if (string.IsNullOrEmpty(company.CompanyName.Trim()))
                    {
                        do
                        {
                            Console.Write("Invalid Input. Please enter again : ");
                            company.CompanyName = Console.ReadLine().ToUpper();
                        } while (string.IsNullOrEmpty(company.CompanyName.Trim()));
                    }
                }

                Console.Write(company.CompanyName + " sells which model type ? (Bike / Car / Both) : ");
                company.ModelType = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(company.ModelType.Trim()))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter valid input : ");
                        company.ModelType = Console.ReadLine().ToUpper();
                    } while (string.IsNullOrEmpty(company.ModelType.Trim()));
                }
                if (company.ModelType != "BIKE" && company.ModelType != "CAR" && company.ModelType != "BOTH")
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter valid input : ");
                        company.ModelType = Console.ReadLine().ToUpper(); ;
                    } while (company.ModelType != "BIKE" && company.ModelType != "CAR" && company.ModelType != "BOTH");
                }

                if (company.ModelType == "BOTH")
                {
                    Console.WriteLine("Enter vehicles information for Bike ..");
                    AddVehicle(company, vehicles);
                    Console.WriteLine("Enter vehicles information for Car ..");
                    AddVehicle(company, vehicles);
                }              

                //vehicles info
                if(company.ModelType == "BIKE" || company.ModelType == "CAR")
                {
                    AddVehicle(company,vehicles);                   
                }

                //distributors info
                Console.Write("How many distributors for " + company.CompanyName + " company ? : ");
                int noOfDistributors = 0;
                while (!int.TryParse(Console.ReadLine(), out noOfDistributors))
                {
                    Console.Write("Please enter a valid numerical input : ");
                }

                for (int k = 1; k <= noOfDistributors; k++)
                {
                    Distributor distributor = new Distributor();
                    Console.Write("Enter {0} distributor name : ", k);
                    distributor.DistributorName = Console.ReadLine().ToUpper();
                    if (string.IsNullOrEmpty(distributor.DistributorName.Trim()))
                    {
                        do
                        {
                            Console.Write("Invalid Input. Please enter again : ");
                            distributor.DistributorName = Console.ReadLine().ToUpper();
                        } while (string.IsNullOrEmpty(distributor.DistributorName.Trim()));
                    }
                    if (distributors.Exists(d => d.DistributorName == distributor.DistributorName))
                    {
                        Console.WriteLine("Distributor already exists.");
                        Console.Write("Please enter another name again : ");
                        distributor.DistributorName = Console.ReadLine().ToUpper();

                        if (string.IsNullOrEmpty(distributor.DistributorName.Trim()))
                        {
                            do
                            {
                                Console.Write("Invalid Input. Please enter again : ");
                                distributor.DistributorName = Console.ReadLine().ToUpper();
                            } while (string.IsNullOrEmpty(distributor.DistributorName.Trim()));
                        }
                    }
                    Console.Write("Enter distributor {0} commission % (10-30) : ", k);
                    double dc = distributor.DistributorCommission;

                    dc = distributor.DistributorCommission;
                    while (!double.TryParse(Console.ReadLine(), out dc) || (dc < 10 || dc > 30))
                    {
                        Console.Write("Please enter a valid input : ");
                    }
                    distributor.DistributorCommission = dc;
                    //add distributor to list
                    distributor.CompanyName = company.CompanyName;
                    distributors.Add(distributor);
                    company.Distributors = distributors;
                }
                //add company to list
                companies.Add(company);
            }

            //display company list with vehicle list and distributor list
            foreach (Company company in companies)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Company name : " + company.CompanyName);
                Console.WriteLine("Model type : " + company.ModelType);
                foreach (Vehicle vehicle in vehicles.FindAll((vehicle) => vehicle.CompanyName.Equals(company.CompanyName)))
                {
                    Console.WriteLine("Vehicle name : " + vehicle.VehicleName);
                    Console.WriteLine("Vehicle price : " + vehicle.VehiclePrice);
                }
                foreach (Distributor distributor in distributors.FindAll((distributor) => distributor.CompanyName.Equals(company.CompanyName)))
                {
                    Console.WriteLine("Distributor name : " + distributor.DistributorName);
                    Console.WriteLine("Distributor commission % : " + distributor.DistributorCommission);
                }
            }

            //minimum commission
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Enter vehicle name to find minimum commission distributor : ");
            string vehicleNameToFind = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(vehicleNameToFind.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter again : ");
                    vehicleNameToFind = Console.ReadLine().ToUpper();
                } while (string.IsNullOrEmpty(vehicleNameToFind.Trim()));
            }

            //distributor
            Distributor minCommissionDistributor = null;
            //commission
            double minCommission = int.MaxValue;
            double commissionAmount = 0;
            foreach (Company company in companies)
            {
                foreach (Vehicle vehicle in company.Vehicles.FindAll((vehicle) => vehicle.CompanyName.Equals(company.CompanyName)))
                {
                    if (vehicle.VehicleName == vehicleNameToFind)
                    {
                        foreach (Distributor distributor in company.Distributors.FindAll((distributor) => distributor.CompanyName.Equals(company.CompanyName)))                      
                        {
                            if (distributor.DistributorCommission < minCommission)
                            {
                                minCommission = distributor.DistributorCommission;
                                minCommissionDistributor = distributor;
                                commissionAmount = vehicle.VehiclePrice + (vehicle.VehiclePrice * distributor.DistributorCommission / 100);
                            }
                        }
                    }
                }
            }
            if (minCommissionDistributor != null)
            {
                Console.WriteLine("Name of vehicle : " + vehicleNameToFind);
                Console.WriteLine("Price of Vehicle with commission : " + commissionAmount);
                Console.WriteLine("Minimum commission distributor : " + minCommissionDistributor.DistributorName);
            }
            else
            {
                Console.WriteLine("Vehicle not found ");
            }
            Console.ReadKey();
        }
        public static void AddVehicle(Company company,List<Vehicle> vehicles)
        {
            Console.Write("Number of vehicles ? : ");
            int noOfVehicles;
            while (!int.TryParse(Console.ReadLine(), out noOfVehicles))
            {
                Console.Write("Please enter a valid numerical input : ");
            }

            for (int j = 1; j <= noOfVehicles; j++)
            {
                Vehicle vehicle = new Vehicle();
                Console.Write("Enter vehicle {0} name : ", j);
                vehicle.VehicleName = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(vehicle.VehicleName.Trim()))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter again : ");
                        vehicle.VehicleName = Console.ReadLine().ToUpper();
                    } while (string.IsNullOrEmpty(vehicle.VehicleName.Trim()));
                }
                if (vehicles.Exists(v => v.VehicleName == vehicle.VehicleName))
                {
                    Console.WriteLine("Vehicle already exists.");
                    Console.Write("Please enter another name again : ");
                    vehicle.VehicleName = Console.ReadLine().ToUpper();

                    if (string.IsNullOrEmpty(vehicle.VehicleName.Trim()))
                    {
                        do
                        {
                            Console.Write("Invalid Input. Please enter again : ");
                            vehicle.VehicleName = Console.ReadLine().ToUpper();
                        } while (string.IsNullOrEmpty(vehicle.VehicleName.Trim()));
                    }
                }
                Console.Write("Enter vehicle price (40,000 - 5,00,000) : ");
                double vp = vehicle.VehiclePrice;
                while (!double.TryParse(Console.ReadLine(), out vp) || (vp < 40000 || vp > 500000))
                {
                    Console.Write("Please enter a valid input : ");
                }
                vehicle.VehiclePrice = vp;
                //add vehicle to list

                vehicle.CompanyName = company.CompanyName;
                vehicles.Add(vehicle);
                company.Vehicles = vehicles;
            }
        }
    }
    
}
