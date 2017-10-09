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
            rooms = new Room[y][];
            for(int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = new Room[x];
            }
        }

        public void CreateRooms()
        {
            Random rdm = new Random();
            int randomX = rdm.Next(0, rooms.Length);
            int randomY = rdm.Next(0, rooms[0].Length);

            for(int y = 0; y < rooms.Length; y++)
            {
                for(int x = 0; x < rooms[y].Length; x++)
                {
                    if(y == randomY && x == randomX)
                    {
                        rooms[y][x] = new Room(true);
                    }
                    else
                    {
                        rooms[y][x] = new Room(false);
                    }
                }
            }
        }

        public void Print()
        {
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();

            for (int y = 0; y < rooms.Length; y++)
            {
                for(int x = 0; x < rooms[y].Length; x++)
                {
                    var room = rooms[y][x];
                    str1.Append(room.ToString());

                    if (y != rooms.Length - 1)
                    {
                        if (room.down == null)
                        {
                            str2.Append(" ");
                        }
                        else
                        {
                            if (room.down.isCollapsed)
                            {
                                str2.Append("#");
                            }
                            else
                            {
                                str2.Append("|");
                            }
                            
                        }
                    }

                    if (x != rooms[y].Length - 1)
                    {
                        if (room.right == null)
                        {
                            str1.Append(" ");
                        }
                        else if (room.right != null)
                        {
                            if (room.right.isCollapsed)
                            {
                                str1.Append("#");
                            }
                            else
                            {
                                str1.Append("-");
                            }
                            
                        }
                        str2.Append(" ");
                    }
                }
                Console.WriteLine(str1);
                Console.WriteLine(str2);
                str1.Clear();
                str2.Clear();
            }
            
        }
    }
}
