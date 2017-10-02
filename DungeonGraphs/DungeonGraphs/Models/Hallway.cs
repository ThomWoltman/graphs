using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs.Models
{
    class Hallway
    {
        public Room room1;
        public Room room2;
        public bool isCollapsed;

        public Hallway(Room room1, Room room2)
        {
            this.room1 = room1;
            this.room2 = room2;
            isCollapsed = false;
        }
    }
}
