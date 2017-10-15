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
        public int Execute(Room start) //Breadth-first search algorithm
        {
            //local variables
            List<Room> queue = new List<Room>();
            HashSet<Room> visited = new HashSet<Room>();
            int result=0;

            //adds fist room to the queue 
            queue.Add(start);
            visited.Add(start);

            Room room = queue.First();
            //loop untill the stairs in found
            while (!room._isStair) {
                 room = queue.First();
                queue.RemoveAt(0);

                Room down = null; 
                Room top = null;
                Room left= null;
                Room right = null;

                //null checks connected rooms
                if (room.down != null) {
                     down = room.Equals(room.down.room1) ? room.down.room2 : room.down.room1;
                }
                if (room.top != null)
                {
                     top = room.Equals(room.top.room1) ? room.top.room2 : room.top.room1;
                }
                if (room.left != null)
                {
                     left = room.Equals(room.left.room1) ? room.left.room2 : room.left.room1;
                }
                if (room.right != null)
                {
                     right = room.Equals(room.right.room1) ? room.right.room2 : room.right.room1;
                }

                //looks if the room is already visited
                if (!visited.Contains(right) && right != null)
                {
                    visited.Add(right);
                    queue.Add(right);
                }
                else if (!visited.Contains(left) && left != null)
                {
                    visited.Add(left);
                    queue.Add(left);
                }

                else if (!visited.Contains(down) && down != null)
                {
                    visited.Add(down);
                    queue.Add(down);
                    result++;
                }
                else if (!visited.Contains(top) && top != null)
                {
                    visited.Add(top);
                    queue.Add(top);
                    result--;
                }
            }


            return result;
        }



   

    }
}
