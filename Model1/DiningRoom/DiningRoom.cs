using System.Collections.Generic;

namespace Model.DiningRoom
{
    public class DiningRoom
    {
        public List<Table> Tables { get; private set; }
        public Reception Reception { get; private set; }
        public Butler Butler { get; private set; }
        public List<HeadWaiter> HeadWaiters { get; private set; }
        public List<Waiter> Waiters { get; private set; }
        //public List<Dishwasher> Dishwashers { get; private set; }

        public DiningRoom(int nbOfHeadWaiter, int nbOfWaiter/*, int nbOfCommis*/)
        {
            Butler = new Butler(this);
            HeadWaiters = new List<HeadWaiter>();
            Waiters = new List<Waiter>();
            for (int i = 0; i < nbOfHeadWaiter; i++)
                HeadWaiters.Add(new HeadWaiter(this));
            for (int i = 0; i < nbOfWaiter; i++)
                Waiters.Add(new Waiter(this));
            /*for (int i = 0; i < nbOfCommis; i++)
                Dishwashers.Add(new Dishwasher(this));*/
            Tables = new List<Table>();
            Tables.Add(new Table(1, 1, 4));
            Tables.Add(new Table(1, 2, 4));
            Tables.Add(new Table(2, 1, 2));
            Tables.Add(new Table(2, 2, 2));
            Reception = new Reception();
        }
    }

}
