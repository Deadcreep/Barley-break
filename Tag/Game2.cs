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
    }
}
