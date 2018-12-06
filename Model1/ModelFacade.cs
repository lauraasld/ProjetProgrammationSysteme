using System.Collections.Generic;

namespace Model
{
    public class ModelFacade
    {
        public DiningRoom.DiningRoom DiningRoom;
        public Kitchen.Kitchen Kitchen;
        public List<PositionedElement> Element { get; set; }

        private Kitchen.Kitchen kitchen;
        private DiningRoom.DiningRoom diningRoom;
        private PositionedElement positionedElement;

    }
}
