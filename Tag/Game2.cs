using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game2 : Game
    {
        protected override void FillField(int[] values)
        {
            new Random().Shuffle<int>(ref values);
            base.FillField(values);
        }

        public Game2(params int[] list) : base(list)
        {            
        }

        public bool IsCompleted()
        {
            int val = 0;
            for (int x = 0; x < sideLength; x++)
                for (int y = 0; y < sideLength; y++)
                {
                    if (knuckles[x, y] != val)
                        return false;
                    val++;
                }
            return true;
        }
    }
}
