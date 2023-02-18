using System.Collections.Generic;

namespace CompanyDistributor
{
    public class Company
    {
        public string companyName { get; set; }
        public string modelType { get; set; }
        public List<Vehicle> vehicles { get; set; }
        public List<Distributor> distributors { get; set; }
    }
}
