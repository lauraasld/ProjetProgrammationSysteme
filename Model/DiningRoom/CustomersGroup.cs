using System;
namespace DiningRoom {
	public class CustomersGroup : PositionedElement  {
		public List<Customer> Customers { get; }
		public bool HasBooked { get; }

		public CustomersGroup(int customersNumber) {
			throw new System.Exception("Not implemented");
		}

		private Customer customer;


	}

}
