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
            
            Game game = new Game(0, 1, 2, 3, 4, 5, 6, 7, 8);

            Printer.PrintBoard(game);

            while (!game.IsCompleted())
            {
                try
                {
                    string s = Console.ReadLine();
                    game.Shift(int.Parse(s));
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Printer.PrintBoard(game);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } 
            }
        }       
    }
}
