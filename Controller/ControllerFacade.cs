using View;
using Model;

namespace Controller
{
    public class ControllerFacade : IController
    {
        private IModel model;
        private IView view;

        public ControllerFacade()
        {
            
        }

        public void GetOrderPerformer()
        {
            throw new System.Exception("Not implemented");
        }
        public void GetModel()
        {
            throw new System.Exception("Not implemented");
        }
        public void GetView()
        {
            throw new System.Exception("Not implemented");
        }

        public void PerformOrder(IUserInput userInput)
        {
            throw new System.Exception("Not implemented");
        }

        public void RefreshPersonPosition(PositionedElement person)
        {
            throw new System.Exception("Not implemented");
        }
    }
}
