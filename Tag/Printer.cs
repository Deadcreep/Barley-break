using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    static class Printer
    {
        public static void PrintBoard(Game game)
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

    }
}
