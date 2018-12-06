using Model;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace View
{
    public class ViewFacade : IView
    {
        private IEventPerformer eventPerformer;
        private Dictionary<Ellipse, PositionedElement> tables;
        private Dictionary<Polygon, PositionedElement> chairs;
        private Dictionary<Rectangle, PositionedElement> persons;

        public void GetEventPerformer()
        {
            throw new System.Exception("Not implemented");
        }
        public void DisplayMessage(string message)
        {
            throw new System.Exception("Not implemented");
        }
        public void RefreshPersonPosition(PositionedElement person)
        {
            throw new System.Exception("Not implemented");
        }
    }
}
