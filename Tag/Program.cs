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
                //Game3 CSVGame = Reader.FromCSV("input.csv");
                //Printer.PrintBoard(CSVGame);

                //Printer.PrintBoard(game);      
                Printer.PrintMenu();
                Printer.PrintBoard(game);
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
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}
