using System;
public class UserInput : IUserInput  {
	private Order order;

	public void UserOrder(Order order) {
		throw new System.Exception("Not implemented");
	}
	public Order GetOrder() {
		return this.order;
	}

}
