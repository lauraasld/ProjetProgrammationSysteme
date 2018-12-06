using System;
public class Controller : IController  {
	private IModel model;
	private IView view;

	public Controller() {
		throw new System.Exception("Not implemented");
	}
	public void GetOrderPerformer() {
		throw new System.Exception("Not implemented");
	}
	public void GetModel() {
		throw new System.Exception("Not implemented");
	}
	public void GetView() {
		throw new System.Exception("Not implemented");
	}
	public void PerformOrder(IUserInput userInput) {
		throw new System.Exception("Not implemented");
	}
	public void RefreshPersonPosition(PositionedElement person) {
		throw new System.Exception("Not implemented");
	}

	private Simulation controller2;

	private TESTModel tESTModel;
	private TESTView tESTView;

}
