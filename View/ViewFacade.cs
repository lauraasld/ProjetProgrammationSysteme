using Model;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace View
{
    public class ViewFacade : IView
    {
        IModel model;
        public IEventPerformer eventPerformer { get; private set; }
        private Dictionary<Ellipse, PositionedElement> tables;
        private Dictionary<Polygon, PositionedElement> chairs;
        private Dictionary<Rectangle, PositionedElement> persons;

        public ViewFacade(IModel model, IEventPerformer eventPerformer)
        {
            this.model = model;
            this.eventPerformer = eventPerformer;
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
