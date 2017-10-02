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


        public Room(bool isStair)
        {
            _isStair = isStair;
        }
    }
}
