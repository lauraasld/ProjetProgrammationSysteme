using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class CustomersGroup : PositionedElement
    {
        public List<Customer> Customers { private set; get; }
        public bool HasBooked { private set; get; }

        public CustomersGroup(List<Customer> customers, bool hasBooked)
        {
            Customers = customers;
            HasBooked = hasBooked;
        }

    }

}
