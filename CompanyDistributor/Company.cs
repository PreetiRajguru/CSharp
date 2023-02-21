using System.Collections.Generic;

namespace CompanyDistributor
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string ModelType { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Distributor> Distributors { get; set; }
    }
}
