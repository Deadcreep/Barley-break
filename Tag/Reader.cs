using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tag
{
    static class Reader
    {
        public static Game3 FromCSV(string filename)
        {
            Game3 game = new Game3();
            string[] field = File.ReadAllLines(filename);
            List<int> knuckles = new List<int>();

            for (int i = 0; i < field.Length; i++)
            {
                var numbers = field[i].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length != field.Length)
                    throw new Exception("Serrated edge");

                for (int j = 0; j < numbers.Count(); j++)
                {
                    knuckles.Add(Convert.ToInt32(numbers[j]));

                }
            }
            int[] final = knuckles.ToArray();
            game = new Game3(final);
            return game;
        }
    }
}
