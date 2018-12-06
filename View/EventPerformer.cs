using System;
public class EventPerformer : IEventPerformer  {
	public IOrderperformer OrderPerformer;

	public EventPerformer(ref IOrderPerformer orderPerformer) {
		throw new System.Exception("Not implemented");
	}
	public void PerformEvent() {
		throw new System.Exception("Not implemented");
	}
	public void SetOrderPerformer(ref object orderPerformer) {
		throw new System.Exception("Not implemented");
	}
	public void EventPerform(ref KeyEvent keyCode) {
		throw new System.Exception("Not implemented");
	}

	private TESTView eventPerformer2;

}
