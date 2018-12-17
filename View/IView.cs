using Model;

namespace View
{
    public interface IView
    {
        IEventPerformer eventPerformer { get; }
        IModel Model { get; set; }
        MainWindow MainWindow { get; }
        void DisplayMessage(string message);
        void Start();
        //void RefreshPersonPosition(PositionedElement person);

    }
}