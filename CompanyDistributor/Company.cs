using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDistributor
{
    public class Company
    {
        public string companyName { get; set; }
        public string modelType { get; set; }
        public List<Vehicle> vehicles { get;set; }
        public List<Distributor> distributors { get;set; }


    }
}
