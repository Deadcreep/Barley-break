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
            this.coordinates = new Coordinate(coordinates.x, coordinates.y);
        }
    }

    class Game3 : Game2
    {
        public List<History> history { get; private set; } = new List<History>();
        int position = -1;
        public Game3(params int[] list) : base(list)
        {
            //history.Add(new History(0, GetLocation(0)));
        }

        public override void Randomize()
        {
            history.Clear();
            base.Randomize();
            position = -1;
        }

       
        
        public override void Shift(int value)
        {
            base.Shift(value);
            if (position != history.Count - 1)
            {
                history = history.Take(position + 1).ToList();
            }
            history.Add(new History(value, GetLocation(0)));
            position++;
        }
        
        public void Undo()
        {
            if (history.Count == 0)
                throw new ArgumentException("Can't undo");
            var temp = history[position];            
            base.Shift(temp.value);
            position--;
        }

        public void Redo()
        {
            if (history.Count == 0 || position >= history.Count - 1)
                throw new ArgumentException("Can't redo");
            var temp = history[position+1];
            base.Shift(temp.value);
            position++;            
        }
    }
}
