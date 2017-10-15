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
                    case "grenade":
                        new Grenade().DropGrenade(dungeon);
                        break;
                    case "talisman":
                        Console.WriteLine(new Talisman().Execute(dungeon.rooms.First().First()));
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

        static Dungeon NewDungeon()
        {
            Console.WriteLine("Make a new dungeon");
            Console.WriteLine("x length?: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("y length?: ");
            int y = int.Parse(Console.ReadLine());

            var dungeon = new Dungeon(x, y);
            dungeon.CreateRooms();
            dungeon.AddHallways();

            return dungeon;
        }
    }
}
