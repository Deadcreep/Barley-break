using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    interface IPlayable
    {
        int sideLength { get; }
        bool IsCompleted();
        void Shift(int value);
        void Randomize();
        int this[int x, int y]
        {
            get;
        }
    }
}
