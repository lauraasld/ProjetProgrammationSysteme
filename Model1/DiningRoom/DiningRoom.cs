using Model.Kitchen;
using System.Collections.Generic;

namespace Model.DiningRoom
{
    public class DiningRoom
    {
        public List<Table> Tables;
        public Reception Reception;
        public Countertop Countertop { get; }
    }

}
