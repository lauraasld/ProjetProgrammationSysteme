using Model;
using System;

namespace View
{
    public interface IView
    {
        void GetEventPerformer();
        void DisplayMessage(string message);
        void RefreshPersonPosition(PositionedElement person);

    }
}