using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class CustomersGroup
    {
        public List<Customer> Customers { private set; get; }
        public bool HasBooked { private set; get; }

        public CustomersGroup(List<Customer> customers, bool hasBooked = false)
        {
            Customers = customers;
            HasBooked = hasBooked;
        }
    }
}
