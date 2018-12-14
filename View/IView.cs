using Model;
using System;

namespace View
{
    public interface IView
    {
        IEventPerformer eventPerformer { get; }
        void DisplayMessage(string message);
        //void RefreshPersonPosition(PositionedElement person);

    }
}