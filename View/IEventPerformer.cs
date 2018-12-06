using System;
public interface IEventPerformer {
	void EventPerform(ref KeyEvent keyCode);
	void SetOrderPerformer(ref object orderPerformer);

}
