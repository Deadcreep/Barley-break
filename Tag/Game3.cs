using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    struct History
    {
        public readonly int value;
        public readonly Coordinate coordinates;
        public History(int value, Coordinate coordinates)
        {
            this.value = value;
            this.coordinates = new Coordinate(coordinates.x + 1, coordinates.y + 1);
        }
    }

    class Game3 : Game2
    {
        public readonly List<History> history;
        int tmp = 0;
        public Game3(params int[] list) : base(list)
        {
            history = new List<History>();
        }

        public override void Shift(int value)
        {
            base.Shift(value);
            history.Add(new History(value, GetLocation(0)));
        }

        public void CancelStep()
        {

            if (history.Count == 0 || tmp == history.Count)
                throw new ArgumentException("Can't cancel");
            var temp = history.Last();            
            Shift(temp.value);
            history.Remove(history.Last());
            tmp = history.Count;
        }
    }
}
