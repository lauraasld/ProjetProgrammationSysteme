using Model;

namespace View
{
    public interface IView
    {
        IModel Model { get; set; }
        MainWindow MainWindow { get; }
        void DisplayMessage(string message);
        void Start();
        //void RefreshPersonPosition(PositionedElement person);

    }
}