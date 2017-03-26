using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game3 game = new Game3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15);
                ConsoleuUI c = new ConsoleuUI(game);
                //Game3 CSVGame = Reader.FromCSV("input.csv");
                //Printer.PrintBoard(CSVGame);

                //Printer.PrintBoard(game);      
                c.Play();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}
