using System.Collections.Generic;

namespace Model
{
    public class ModelFacade
    {
        public static int MinuteToMilisecondsMultiplier = 60000;

        public DiningRoom.DiningRoom DiningRoom = new DiningRoom.DiningRoom();
        public Kitchen.Kitchen Kitchen = new Model.Kitchen.Kitchen();
        public List<PositionedElement> Element { get; set; }
    }
}
