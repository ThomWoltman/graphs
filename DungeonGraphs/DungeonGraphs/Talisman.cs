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
            Dictionary<Room, int> visited = new Dictionary<Room, int>();

            //adds fist room to the queue 
            queue.Add(start);
            visited.Add(start,0);

            Room room = queue.First();
            //loop untill the stairs in found
            while (true) {
                 room = queue.First();

             

                queue.RemoveAt(0);

                Room down = null; 
                Room top = null;
                Room left= null;
                Room right = null;

                //null checks connected rooms
                if (room._isStair) {
                    return 0;
                }
                if (room.down != null && !room.down.isCollapsed) {
                     down = room.Equals(room.down.room1) ? room.down.room2 : room.down.room1;
                    if (down._isStair)
                    {
                        return visited.FirstOrDefault(x => x.Key == room).Value+1;
                    }
                }
                if (room.top != null &&  !room.top.isCollapsed)
                {
                     top = room.Equals(room.top.room1) ? room.top.room2 : room.top.room1;
                    if (top._isStair)
                    {
                        return visited.FirstOrDefault(x => x.Key == room).Value + 1;
                    }
                }
                if (room.left != null && !room.left.isCollapsed)
                {
                     left = room.Equals(room.left.room1) ? room.left.room2 : room.left.room1;
                    if (left._isStair)
                    {
                        return visited.FirstOrDefault(x => x.Key == room).Value + 1;
                    }
                }
                if (room.right != null && !room.right.isCollapsed)
                {
                     right = room.Equals(room.right.room1) ? room.right.room2 : room.right.room1;
                    if (right._isStair)
                    {
                        return visited.FirstOrDefault(x => x.Key == room).Value + 1;
                    }
                }


                //looks if the room is already visited
                if ( right != null && !visited.ContainsKey(right) )
                {
                    
                    int i;
                     i = visited.FirstOrDefault(x => x.Key == room).Value;
                    i++;
                    visited.Add(right, i);
                    queue.Add(right);
                }
                 if (left != null && !visited.ContainsKey(left))
                {
                    int i;
                  
                        i = visited.Where(x => x.Key == room).First().Value;
                    i++;
                    visited.Add(left, i);
                    queue.Add(left);
                }

                 if ( down != null && !visited.ContainsKey(down))
                {
                    int i;

                         i = visited.Where(x => x.Key == room).First().Value;
                    i++;
                    visited.Add(down, i);
                    queue.Add(down);
                }
                 if ( top != null && !visited.ContainsKey(top)  )
                {
                    int i;

                        i = visited.Where(x => x.Key == room).First().Value;

                    i++;
                    visited.Add(top, i);
                    queue.Add(top);
                }
            }


        }



   

    }
}
