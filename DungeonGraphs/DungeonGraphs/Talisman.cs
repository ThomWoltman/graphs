using DungeonGraphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs
{
    public class Talisman
    {
        public int Execute(Room room) //Breadth-first search algorithm
        {
            List<Room> queue = new List<Room>();
            HashSet<Room> visited = new HashSet<Room>();

            queue.Add(room);

            while (queue.Count == 0) {
                Room visitRoom = queue.First();
                queue.RemoveAt(0);

            }
            int result = 0;
            

            return result;
        }
    }
}
