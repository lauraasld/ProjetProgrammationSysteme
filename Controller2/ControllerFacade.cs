using View;
using Model;

namespace Controller
{
    public class ControllerFacade : IController
    {
        public IModel model { get;  private set; }
        public IView view { get; private set; }

        public ControllerFacade(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            Simulation simulation = new Simulation(this);
            simulation.InitializeSimulation();
            simulation.StartSimulation();
        }

        /*public void GetModel()
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
        public void GetOrderPerformer()
        {
            throw new System.Exception("Not implemented");
        }*/
    }
}
