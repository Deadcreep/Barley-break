using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    static class Printer
    {
        public static void PrintBoard(Game3 game)
        {

            int a = 0;
            int b = 0;
            for (a = 0; a < game.sideLength; a++)
            {
                for (b = 0; b < game.sideLength; b++)
                    Console.Write(game[a, b] + "\t");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void PrintHistory(Game3 game)
        {
            for (int i = 0; i < game.history.Count; i++)
                Console.WriteLine("Knuckle " + game.history[i].value + "\t coordinate: " + game.history[i].coordinates.x + " : " + game.history[i].coordinates.y);
        }

    }
}
