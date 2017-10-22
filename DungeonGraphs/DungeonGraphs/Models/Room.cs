using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs.Models
{
    public class Room
    {
        public bool _isStair;
        public Hallway top;
        public Hallway down;
        public Hallway left;
        public Hallway right;
        public bool me;
        public Room(bool isStair)
        {
            _isStair = isStair;
            me = false;
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
            if (me)
            {
                return ":D";
            }
            return "R";
        }
    }
}
