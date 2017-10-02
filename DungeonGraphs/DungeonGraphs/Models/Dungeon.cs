using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs.Models
{
    class Dungeon
    {
        public Room[][] rooms;

        public Dungeon(int x, int y)
        {
            rooms = new Room[x][];
            for(int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = new Room[y];
            }
        }

        public void createRooms()
        {
            Random rdm = new Random();
            int randomX = rdm.Next(0, rooms.Length);
            int randomY = rdm.Next(0, rooms[0].Length);

            for(int x = 0; x < rooms.Length; x++)
            {
                for(int y = 0; y < rooms[x].Length; y++)
                {
                    if(x == randomX && y == randomY)
                    {
                        rooms[x][y] = new Room(true);
                    }
                    else
                    {
                        rooms[x][y] = new Room(false);
                    }
                }
            }
        }
    }
}
