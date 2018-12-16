namespace View
{
    public interface IUserInputObserver
    {
        void UserInputReceived(Order parameters, double newSimulationSpeed = -1);
    }
}
