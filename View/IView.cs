using System;

public interface IView {
	void GetEventPerformer();
	void DisplayMessage(ref String message);
	void RefreshPersonPosition(ref PositionedElement person);

}
