using System;
public class View : IView  {
	private IEventPerformer eventPerformer;
	private List<PositionedElements> tables;
	private List<PositionedElements> chairs;
	private List<PositionedElements> persons;

	public void GetEventPerformer() {
		throw new System.Exception("Not implemented");
	}
	public void DisplayMessage(ref String message) {
		throw new System.Exception("Not implemented");
	}
	public void RefreshPersonPosition(ref PositionedElement person) {
		throw new System.Exception("Not implemented");
	}

	private EventPerformer eventPerformer2;
	private System.Windows.Shapes.Ellipse system.Windows.Shapes.Ellipse;
	private System.Windows.Shapes.Polygon system.Windows.Shapes.Polygon;
	private System.Windows.Shapes.Rectangle system.Windows.Shapes.Rectangle;

}
