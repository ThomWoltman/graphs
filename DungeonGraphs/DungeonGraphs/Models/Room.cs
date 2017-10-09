using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs.Models
{
    class Room
    {
        public bool _isStair;
        public Hallway top;
        public Hallway down;
        public Hallway left;
        public Hallway right;

        public Room(bool isStair)
        {
            _isStair = isStair;
            top = null;
            down = null;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            if (_isStair)
            {
                return "S";
            }
            return "R";
        }
    }
}
