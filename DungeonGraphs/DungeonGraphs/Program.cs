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
            var Dungeon = new Dungeon(9, 9);
            Dungeon.createRooms();

            Dungeon.print();

            Console.ReadKey();
        }
    }
}
