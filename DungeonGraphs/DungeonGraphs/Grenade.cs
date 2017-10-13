using DungeonGraphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs
{
    public class Grenade
    {
        public List<Hallway> MinimumSpanningTree(Room room) //Prims minimum spanning tree alghorithm
        {
            var hallways = new List<Hallway>();
            var rooms = new List<Room>();
            MinimumSpanningTree(room, hallways, rooms);

            return hallways;
        }

        public void MinimumSpanningTree(Room room, List<Hallway> hallways, List<Room> rooms)
        {
            //add room to rooms
            rooms.Add(room);

            MinimumSpanningTree(room.top, room, hallways, rooms);
            MinimumSpanningTree(room.right, room, hallways, rooms);
            MinimumSpanningTree(room.left, room, hallways, rooms);
            MinimumSpanningTree(room.down, room, hallways, rooms);
        }

        public void MinimumSpanningTree(Hallway hallway, Room room, List<Hallway> hallways, List<Room> rooms)
        {
            Room otherRoom;
            if (hallway != null && !hallway.isCollapsed)
            {
                otherRoom = room.Equals(hallway.room1) ? hallway.room2 : hallway.room1;
                if (!rooms.Exists(r => r.Equals(otherRoom)))
                {
                    hallways.Add(hallway);
                    MinimumSpanningTree(otherRoom, hallways, rooms);
                }
            }
        }

        public void DropGrenade(Dungeon dungeon)
        {
            var hallways = dungeon.minHallways;

            for (int y = 0; y < dungeon.rooms.Length; y++)
            {
                for (int x = 0; x < dungeon.rooms[y].Length; x++)
                {
                    var r = dungeon.rooms[y][x];

                    if (r.top != null)
                        r.top.isCollapsed = !hallways.Contains(r.top);
                    if (r.down != null)
                        r.down.isCollapsed = !hallways.Contains(r.down);
                    if (r.right != null)
                        r.right.isCollapsed = !hallways.Contains(r.right);
                    if (r.left != null)
                        r.left.isCollapsed = !hallways.Contains(r.left);
                }
            }
        }
    }
}
