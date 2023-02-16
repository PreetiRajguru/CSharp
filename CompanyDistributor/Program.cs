using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDistributor
{
    public class Program
    {
        static void Main(string[] args)
        {
            //list for storing company, vehicle and distributors data
            List<Company> companies = new List<Company>();
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Distributor> distributors = new List<Distributor>();

            //company info
            Console.Write("How many companies details you want to enter? : ");
            int noOfCompanies = int.Parse(Console.ReadLine());
            for (int i=1;i<=noOfCompanies;i++)
            {
                Company company = new Company();

                Console.Write("Enter Company {0} name : ",i);
                company.companyName = Console.ReadLine();
                Console.Write("Company model type (2 wheeler / 4 wheeler : ");
                company.modelType = Console.ReadLine();

                //vehicles info
                Console.Write("How many vehicles for this model type ? : ");
                int noOfVehicles = int.Parse(Console.ReadLine());
                for (int j=1; j<=noOfVehicles;j++)
                {
                    Vehicle vehicle = new Vehicle();
                    Console.Write("Enter vehicle {0} name : ", j);
                    vehicle.vehicleName = Console.ReadLine();
                    Console.Write("Enter vehicle price : ");
                    vehicle.vehiclePrice = int.Parse(Console.ReadLine());
                    //add vehicle to list
                    vehicles.Add(vehicle);
                    company.vehicles = vehicles;
                }
                
                //distributors info
                Console.Write("How many distributors for {0} company ? : ",i);
                int noOfDistributors = int.Parse(Console.ReadLine());
                for (int k = 1; k <= noOfDistributors; k++)
                {
                    Distributor distributor = new Distributor();
                    Console.Write("Enter distributor {0} name : ", k);
                    distributor.distributorName = Console.ReadLine();
                    Console.Write("Enter distributor {0} commission : ",k);
                    distributor.distributorCommission = int.Parse(Console.ReadLine());
                    //add distributor to list
                    distributors.Add(distributor);
                    company.distributors = distributors;
                }

                //add company to list
                companies.Add(company);
            }

            //display company list with vehicle list and distributor list
            foreach (var i in companies)
            {
                Console.WriteLine("Company name : " + i.companyName);
                Console.WriteLine("Model type : "+i.modelType);
                foreach(var j in vehicles)
                {
                    Console.WriteLine("Vehicle name : " + j.vehicleName);
                     Console.WriteLine("Vehicle price : "+ j.vehiclePrice);
                }
                foreach (var k in distributors)
                {
                    Console.WriteLine("Distributor name : " + k.distributorName);
                    Console.WriteLine("Distributor commission : "+ k.distributorCommission);
                }
            }


            //minimum commission           
            Console.WriteLine("Enter vehicle name to find minimum commission distributor : ");
            string vehicleNameToFind = Console.ReadLine();
            //distributor
            Distributor minCommissionDistributor = null;
            //commission
            double minCommission = 0;
            double vehiclePrice = 0;
            foreach (Company company in companies)
            {
                foreach(Vehicle vehicle in company.vehicles)
                {
                    if(vehicle.vehicleName == vehicleNameToFind)
                    {
                        
                        foreach(Distributor distributor in company.distributors)
                        {
                            if (distributor.distributorCommission > minCommission)
                            {
                                minCommission = distributor.distributorCommission;
                                minCommissionDistributor = distributor;
                                vehiclePrice = vehicle.vehiclePrice;
                            }

                        }
                    }
                }
            }
            if(minCommissionDistributor!= null)
            {
                Console.WriteLine("Minimum distributor : "+ minCommissionDistributor.distributorName);
                Console.WriteLine("Name of vehicle : " + vehicleNameToFind);
                Console.WriteLine("Price of Vehicle" + vehiclePrice);
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            Console.ReadKey();
        }
    }
}
