using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game2 : Game
    {
       
        public Game2(params int[] list) : base(list)
        {

        }

        public virtual void Randomize()
        {
            new Random().Shuffle<int>(ref knuckles);
            for (int x = 0; x < this.sideLength; x++)
            {
                for (int y = 0; y < this.sideLength; y++)
                {
                    var temp = knuckles[x, y];
                    dictionaty[temp] = new Coordinate(x, y);
                }
            }
        }

        protected override void FillField(int[] values)
        {
            base.FillField(values);
            Randomize();
        }


        public bool IsCompleted()
        {
            int max = sideLength - 1;
            int val = 1;
            for (int x = 0; x < sideLength; x++)
                for (int y = 0; y < sideLength; y++)
                {
                    if (x == max && y == max && knuckles[x, y] == 0)
                        return true;

                    if (knuckles[x, y] != val)
                        return false;
                    val++;
                }

            return true;
        }
    }
}
