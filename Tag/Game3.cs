using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    struct Hystory
    {
        public readonly int value;
        public readonly Coordinate coordinates;
        public Hystory(int value, Coordinate coordinates)
        {
            this.value = value;
            this.coordinates = new Coordinate(coordinates.x + 1, coordinates.y + 1);
        }
    }

    class Game3 : Game2
    {
        public readonly List<Hystory> history;

        public Game3(params int[] list) : base(list)
        {
            history = new List<Hystory>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            history.Add(new Hystory(value, GetLocation(0)));
        }
    }
}
