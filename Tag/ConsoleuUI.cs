using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class ConsoleuUI
    {
        IPlayable game;

        public ConsoleuUI(IPlayable g)
        {
            game = g;
            
        }

        public  void PrintBoard( )
        {

            int a = 0;
            int b = 0;

            for (a = 0; a < game.sideLength; a++)
            {
                for (b = 0; b < game.sideLength; b++)
                {
                    Console.Write(game[a, b] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
       

        public void PrintMenu()
        {
            Console.WriteLine("Select:" + Environment.NewLine
                            // + "m: Make step" + Environment.NewLine
                            + "u: Undo" + Environment.NewLine
                            + "y: Redo" + Environment.NewLine
                            + "h: Print history" + Environment.NewLine
                            + "r: Shuffle the field" + Environment.NewLine
                            + "q: Quit" + Environment.NewLine);
        }

        public  void RefreshScreen(Game3 game)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Printer.PrintMenu();
            Printer.PrintBoard(game);
        }

        public void Play()
        {
            c.PrintMenu();
            c.PrintBoard();
            while (!game.IsCompleted())
            {
                try
                {
                    bool tempFlag = true;
                    string s = Console.ReadLine();
                    switch (s)
                    {
                        case "u":
                            game.Undo();
                            Printer.RefreshScreen(game);
                            break;
                        case "y":
                            game.Redo();
                            Printer.RefreshScreen(game);
                            break;
                        case "h":
                            Printer.PrintHistory(game);
                            break;
                        case "q":
                            tempFlag = false;
                            break;
                        case "r":
                            game.Randomize();
                            Printer.RefreshScreen(game);
                            break;
                        default:
                            game.Shift(int.Parse(s));
                            Printer.RefreshScreen(game);
                            break;
                    }

                    if (tempFlag == false)
                        break;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
