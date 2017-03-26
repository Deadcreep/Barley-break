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

        private void PrintBoard( )
        {

            int a = 0;
            int b = 0;

            for (a = 0; a < game.SideLength; a++)
            {
                for (b = 0; b < game.SideLength; b++)
                {
                    Console.Write(game[a, b] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
       

        private void PrintMenu()
        {
            Console.WriteLine("Select:" + Environment.NewLine                                                 
                            + "r: Shuffle the field" + Environment.NewLine
                            + "q: Quit" + Environment.NewLine);
        }

        private void RefreshScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PrintMenu();
            PrintBoard();
        }

        public void Play()
        {
            PrintMenu();
            PrintBoard();
            while (!game.IsCompleted())
            {
                try
                {
                    bool tempFlag = true;
                    string s = Console.ReadLine();
                    switch (s)
                    {
                        
                        case "q":
                            tempFlag = false;
                            break;
                        case "r":
                            game.Randomize();
                            RefreshScreen();
                            break;
                        default:
                            game.Shift(int.Parse(s));
                            RefreshScreen();
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
