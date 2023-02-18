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
                company.companyName = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(company.companyName.Trim()))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter again : ");
                        company.companyName = Console.ReadLine().ToUpper();
                    } while (string.IsNullOrEmpty(company.companyName.Trim()));
                }

                if (companies.Exists(c => c.companyName == company.companyName))
                {
                    Console.WriteLine("Company already exists.");
                    Console.Write("Please enter another name again : ");
                    company.companyName = Console.ReadLine().ToUpper();

                    if (string.IsNullOrEmpty(company.companyName.Trim()))
                    {
                        do
                        {
                            Console.Write("Invalid Input. Please enter again : ");
                            company.companyName = Console.ReadLine().ToUpper();
                        } while (string.IsNullOrEmpty(company.companyName.Trim()));
                    }
                }

                Console.Write(company.companyName + " sells which model type ? (Bike / Car / Both) : ");
                company.modelType = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(company.modelType.Trim()))
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter valid input : ");
                        company.modelType = Console.ReadLine().ToUpper();
                    } while (string.IsNullOrEmpty(company.modelType.Trim()));
                }
                if (company.modelType != "BIKE" && company.modelType != "CAR" && company.modelType != "BOTH")
                {
                    do
                    {
                        Console.Write("Invalid Input. Please enter valid input : ");
                        company.modelType = Console.ReadLine().ToUpper(); ;
                    } while (company.modelType != "BIKE" && company.modelType != "CAR" && company.modelType != "BOTH");
                }

                if (company.modelType == "BOTH")
                {
                    Console.WriteLine("Enter vehicles information for Bike ..");
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
                        vehicle.vehicleName = Console.ReadLine();
                        if (string.IsNullOrEmpty(vehicle.vehicleName.Trim()))
                        {
                            do
                            {
                                Console.Write("Invalid Input. Please enter again : ");
                                vehicle.vehicleName = Console.ReadLine();
                            } while (string.IsNullOrEmpty(vehicle.vehicleName.Trim()));
                        }
                        
                        Console.Write("Enter vehicle price (40,000 - 5,00,000) : ");
                        double vp = vehicle.vehiclePrice;
                        while (!double.TryParse(Console.ReadLine(), out vp) || (vp < 40000 || vp > 500000))
                        {
                            Console.Write("Please enter a valid numerical input : ");
                        }
                        vehicle.vehiclePrice = vp;
                        //add vehicle to list
                        vehicles.Add(vehicle);
                        company.vehicles = vehicles;
                    }

                        Console.WriteLine("Enter vehicles information for Car ..");
                        Console.Write("Number of vehicles ? : ");
                        int noOfCars;
                        while (!int.TryParse(Console.ReadLine(), out noOfCars))
                        {
                            Console.Write("Please enter a valid numerical input : ");
                        }
                        for (int k = 1; k <= noOfCars; k++)
                        {
                            Vehicle vehicle = new Vehicle();
                            Console.Write("Enter vehicle {0} name : ", k);
                            vehicle.vehicleName = Console.ReadLine();
                            if (string.IsNullOrEmpty(vehicle.vehicleName.Trim()))
                            {
                                do
                                {
                                    Console.Write("Invalid Input. Please enter again : ");
                                    vehicle.vehicleName = Console.ReadLine();
                                } while (string.IsNullOrEmpty(vehicle.vehicleName.Trim()));
                            }
                        
                            Console.Write("Enter vehicle price (40,000 - 5,00,000) : ");
                            double cp = vehicle.vehiclePrice;
                            while (!double.TryParse(Console.ReadLine(), out cp) || (cp < 40000 || cp > 500000))
                            {
                                Console.Write("Please enter a valid numerical input : ");
                            }
                            vehicle.vehiclePrice = cp;
                            //add vehicle to list
                            vehicles.Add(vehicle);
                            company.vehicles = vehicles;
                        }         
                }

                //vehicles info
                if(company.modelType == "BIKE" || company.modelType == "CAR")
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
                        vehicle.vehicleName = Console.ReadLine();
                        if (string.IsNullOrEmpty(vehicle.vehicleName.Trim()))
                        {
                            do
                            {
                                Console.Write("Invalid Input. Please enter again : ");
                                vehicle.vehicleName = Console.ReadLine();
                            } while (string.IsNullOrEmpty(vehicle.vehicleName.Trim()));
                        }
                        Console.Write("Enter vehicle price (40,000 - 5,00,000) : ");
                        double vp = vehicle.vehiclePrice;
                        while (!double.TryParse(Console.ReadLine(), out vp) || (vp < 40000 || vp > 500000))
                        {
                            Console.Write("Please enter a valid input : ");
                        }
                        vehicle.vehiclePrice = vp;
                        //add vehicle to list
                        vehicles.Add(vehicle);
                        company.vehicles = vehicles;
                    }
                }

                //distributors info
                Console.Write("How many distributors for " + company.companyName + " company ? : ");
                int noOfDistributors = 0;
                while (!int.TryParse(Console.ReadLine(), out noOfDistributors))
                {
                    Console.Write("Please enter a valid numerical input : ");
                }

                for (int k = 1; k <= noOfDistributors; k++)
                {
                    Distributor distributor = new Distributor();
                    Console.Write("Enter {0} distributor name : ", k);
                    distributor.distributorName = Console.ReadLine();
                    if (string.IsNullOrEmpty(distributor.distributorName.Trim()))
                    {
                        do
                        {
                            Console.Write("Invalid Input. Please enter again : ");
                            distributor.distributorName = Console.ReadLine();
                        } while (string.IsNullOrEmpty(distributor.distributorName.Trim()));
                    }

                    Console.Write("Enter distributor {0} commission % (10-30) : ", k);
                    double dc = distributor.distributorCommission;

                    dc = distributor.distributorCommission;
                    while (!double.TryParse(Console.ReadLine(), out dc) || (dc < 10 || dc > 30))
                    {
                        Console.Write("Please enter a valid input : ");
                    }
                    distributor.distributorCommission = dc;
                    //add distributor to list
                    distributors.Add(distributor);
                    company.distributors = distributors;
                }
                //add company to list
                companies.Add(company);
            }

            //display company list with vehicle list and distributor list
            foreach (Company company in companies)
            {
                Console.WriteLine("");
                Console.WriteLine("Company name : " + company.companyName);
                Console.WriteLine("Model type : " + company.modelType);
                foreach (var j in vehicles)
                {
                    Console.WriteLine("Vehicle name : " + j.vehicleName);
                    Console.WriteLine("Vehicle price : " + j.vehiclePrice);
                }
                foreach (var k in distributors)
                {
                    Console.WriteLine("Distributor name : " + k.distributorName);
                    Console.WriteLine("Distributor commission % : " + k.distributorCommission);
                }
            }

            //minimum commission           
            Console.WriteLine("Enter vehicle name to find minimum commission distributor : ");
            string vehicleNameToFind = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleNameToFind.Trim()))
            {
                do
                {
                    Console.Write("Invalid Input. Please enter again : ");
                    vehicleNameToFind = Console.ReadLine();
                } while (string.IsNullOrEmpty(vehicleNameToFind.Trim()));
            }

            //distributor
            Distributor minCommissionDistributor = null;
            //commission
            double minCommission = int.MaxValue;
            double commissionAmount = 0;
            foreach (Company company in companies)
            {
                foreach (Vehicle vehicle in company.vehicles)
                {
                    if (vehicle.vehicleName == vehicleNameToFind)
                    {
                        foreach (Distributor distributor in company.distributors)
                        {
                            if (distributor.distributorCommission < minCommission)
                            {
                                minCommission = distributor.distributorCommission;
                                minCommissionDistributor = distributor;
                                commissionAmount = vehicle.vehiclePrice + (vehicle.vehiclePrice * distributor.distributorCommission / 100);
                            }
                        }
                    }
                }
            }
            if (minCommissionDistributor != null)
            {
                Console.WriteLine("Name of vehicle : " + vehicleNameToFind);
                Console.WriteLine("Price of Vehicle with commission : " + commissionAmount);
                Console.WriteLine("Minimum commission distributor : " + minCommissionDistributor.distributorName);
            }
            else
            {
                Console.WriteLine("Vehicle not found ");
            }
            Console.ReadKey();
        }
    }
}
