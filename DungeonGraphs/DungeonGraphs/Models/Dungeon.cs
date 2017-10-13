using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGraphs.Models
{
    public class Dungeon
    {
        public Room[][] rooms;
        public List<Room> minRooms;
        public List<Hallway> minHallways;

        public Dungeon(int x, int y)
        {
            minRooms = new List<Room>();
            minHallways = new List<Hallway>();

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

        public void AddHallways()
        {
            Random rdm = new Random();
            for(int y = 0; y < rooms.Length; y++)
            {
                bool down = y != rooms.Length - 1;
                for(int x = 0; x < rooms[y].Length; x++)
                {
                    bool right = x != rooms[y].Length - 1;

                    if (right)
                    {
                        var hw = new Hallway(rooms[y][x], rooms[y][x + 1]);
                        rooms[y][x].right = hw;
                        rooms[y][x+1].left = hw;
                    }
                    if (down)
                    {
                        var hw = new Hallway(rooms[y][x], rooms[y+1][x]);
                        rooms[y][x].down = hw;
                        rooms[y+1][x].top = hw;
                    }
                    
                }
            }
            int rdmy = rdm.Next(rooms.Length);
            int rdmx = rdm.Next(rooms[0].Length);

            new Grenade().MinimumSpanningTree(rooms[rdmy][rdmx], minHallways, minRooms);

            for (int y = 0; y < rooms.Length; y++)
            {
                for (int x = 0; x < rooms[y].Length; x++)
                {
                    var currentroom = rooms[y][x];
                    var random = rdm.Next(3);
                    
                    if (currentroom.right != null && !minHallways.Contains(currentroom.right))
                    {
                        if(random == 1)
                            currentroom.right.isCollapsed = true;
                    }
                    if (currentroom.down != null && !minHallways.Contains(currentroom.down))
                    {
                        if(random == 2)
                            currentroom.down.isCollapsed = true;
                    }

                }
            }
        }

        public void Print()
        {
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            int x;
            int y;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            for(int a = 0; a < rooms[0].Length; a++)
            {
                Console.Write(a + " ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (y = 0; y < rooms.Length; y++)
            {
                for(x = 0; x < rooms[y].Length; x++)
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

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(y + " ");
                Console.ForegroundColor = ConsoleColor.White;
                
                for(int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] == '-' || str1[i] == '|')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (str1[i] == '#')
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str1[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
                Console.Write("  ");

                for (int i = 0; i < str2.Length; i++)
                {

                    if (str2[i] == '-' || str2[i] == '|')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (str2[i] == '#')
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str2[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();

                str1.Clear();
                str2.Clear();
            }
            
        }
    }
}
