using System.Collections.Generic;

namespace Model
{
    public class ModelFacade : IModel
    {
        public static int MinuteToMilisecondsMultiplier = 60000;

        public DiningRoom.DiningRoom DiningRoom { get; set; }
        public Kitchen.Kitchen Kitchen { get; set; }
        public List<PositionedElement> Element { get; set; }

        public ModelFacade(int nbOfCooks, int nbOfCommis, int nbOfDishwashers, int nbOfHeadWaiter, int nbOfWaiter)
        {
            DiningRoom = new DiningRoom.DiningRoom(nbOfHeadWaiter, nbOfWaiter);
            Kitchen = new Kitchen.Kitchen(nbOfCooks, nbOfCommis, nbOfDishwashers);
        }
    }
}
