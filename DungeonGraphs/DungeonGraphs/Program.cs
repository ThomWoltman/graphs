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
            var Dungeon = new Dungeon(5, 5);
            Dungeon.CreateRooms();
            Dungeon.AddHallways();

            Dungeon.Print();

            Console.WriteLine("x");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("y");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("talisman?");
            Console.ReadKey();

            var room = Dungeon.rooms[y][x];

            var result = new Talisman().Execute(room);

            Console.WriteLine("steps = "+result);
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            
        }
    }
}
