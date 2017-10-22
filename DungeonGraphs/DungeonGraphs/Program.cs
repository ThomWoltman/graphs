using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGraphs.Models;

namespace DungeonGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dungeon dungeon = NewDungeon();

            bool isrunning = true;

            while (isrunning)
            {
                Console.Clear();
                dungeon.Print();
                
                Console.WriteLine("[new dungeon] - [grenade] - [talisman] - [quit]");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "new dungeon":
                        dungeon = NewDungeon();
                        break;
                    case "move":
                        dungeon = move(dungeon);
                        break;
                    case "grenade":
                        new Grenade().DropGrenade(dungeon);
                        break;
                    case "talisman":
                        Console.WriteLine(new Talisman().Execute(getMe(dungeon)));
                        Console.Read();
                        break;
                    case "quit":
                        isrunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static Room getMe(Dungeon dugeon)
        {
            Room roomFinal = null;
            foreach (var room in dugeon.rooms)
            {
                foreach (var room1 in room)
                {
                    if (room1.me == true)
                    {
                        roomFinal = room1;

                    }
                }
                foreach (var room2 in room)
                {
                    if (room2.me == true)
                    {
                        roomFinal = room2;
                    }
                }


            }

          

            return roomFinal;
        }

        static Dungeon move(Dungeon dugeon)
        {
            var input = Console.ReadLine();
            Room roomFinal = getMe(dugeon);

            if (input == "w") {
               Room top = roomFinal.Equals(roomFinal.top.room1) ? roomFinal.top.room2 : roomFinal.top.room1;

                top.me = true;
                roomFinal.me = false;

            }
            if (input == "s")
            {
                Room down = roomFinal.Equals(roomFinal.down.room1) ? roomFinal.down.room2 : roomFinal.down.room1;

                down.me = true;
                roomFinal.me = false;

            }
            if (input == "a")
            {
                Room left = roomFinal.Equals(roomFinal.left.room1) ? roomFinal.left.room2 : roomFinal.left.room1;

                left.me = true;
                roomFinal.me = false;

            }
            if (input == "d")
            {
                Room right = roomFinal.Equals(roomFinal.right.room1) ? roomFinal.right.room2 : roomFinal.right.room1;

                right.me = true;
                roomFinal.me = false;
            }

            return dugeon;
        }

        static Dungeon NewDungeon()
        {
            Console.WriteLine("Make a new dungeon");
            Console.WriteLine("x length?: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("y length?: ");
            int y = int.Parse(Console.ReadLine());

            var dungeon = new Dungeon(x, y);
            Console.WriteLine("Make a new dungeon");
            Console.WriteLine("X as position: ");
            int meX = int.Parse(Console.ReadLine());
            Console.WriteLine("Y as position: ");
            int meY = int.Parse(Console.ReadLine());
            dungeon.CreateRooms(meX, meY);
            dungeon.AddHallways();

            return dungeon;
        }


    
    }
}
