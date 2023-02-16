using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDistributor
{
    public class Distributor
    {
        public string distributorName { get; set; }
        public double distributorCommission { get; set; }

      /*  public double CalculateCommission(List<Vehicle> vehicles)
        {
            Vehicle vehicleobj= new Vehicle();
            double commission = vehicleobj.vehiclePrice + vehicleobj.vehiclePrice * (distributorCommission / 100);
            return commission;
        }*/
    }
}
