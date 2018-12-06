namespace View
{
    public class EventPerformer : IEventPerformer
    {
        public IOrderPerformer OrderPerformer;

        public EventPerformer(IOrderPerformer orderPerformer)
        {
            throw new System.Exception("Not implemented");
        }
        public void PerformEvent()
        {
            throw new System.Exception("Not implemented");
        }
        public void SetOrderPerformer(object orderPerformer)
        {
            throw new System.Exception("Not implemented");
        }
        public void EventPerform(int keyCode)
        {
            throw new System.Exception("Not implemented");
        }

    }
}
