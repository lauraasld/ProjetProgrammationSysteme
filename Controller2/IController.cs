using Model;
using View;

namespace Controller
{
    public interface IController
    {
        //void GetOrderPerformer();
        IModel model { get; }
        IView view { get; }

    }
}
