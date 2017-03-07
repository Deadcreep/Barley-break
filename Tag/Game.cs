using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{

    struct Coordinate
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Coordinate(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
    }


    class Game
    {
        protected int[,] knuckles;
        public int sideLength { get; private set; }
        protected Dictionary<int, Coordinate> dictionaty = new Dictionary<int, Coordinate>();

        public Game(params int[] list)
        {
            Validate(list);
            sideLength = Convert.ToInt32(Math.Sqrt(list.Length));
            knuckles = new int[sideLength, sideLength];
            FillField(list);
        }

        private void Validate(int[] list)
        {
            if (Math.Pow(Math.Sqrt(list.Length), 2) != list.Length)
                throw new ArgumentException("Wrong number of knuckles");

            for (int i = 0; i < list.Length; i++)
            {
                if (!list.Contains(i))
                    throw new ArgumentException("Wrong nuckles");
            }
        }

        protected virtual void FillField(int[] values)
        {
            int i = 0;
            for (int x = 0; x < sideLength; x++)
                for (int y = 0; y < sideLength; y++)
                {
                    knuckles[x, y] = values[i];
                    dictionaty.Add(values[i], new Coordinate(x, y));
                    i++;
                }
        }

        public int this[int x, int y]
        {
            get
            {
                if (x >= sideLength || y >= sideLength)
                {
                    throw new IndexOutOfRangeException();
                }
                return knuckles[x, y];
            }
        }

        public Coordinate GetLocation(int value)
        {
            if (dictionaty.ContainsKey(value) == false)
                throw new ArgumentException("Nonexistent knuckle");
            return dictionaty[value];
        }

        public virtual void Shift(int value)
        {
            if (value == 0)
            {
                throw new ArgumentException("Incorrect value");
            }

            var source = GetLocation(value);
            var dest = GetLocation(0);
            if (Math.Abs(source.x + source.y - dest.x - dest.y) != 1)
            {
                throw new Exception("Can't move " + value);
            }

            knuckles[source.x, source.y] = 0;
            knuckles[dest.x, dest.y] = value;

            var temp = dictionaty[0];
            dictionaty[0] = dictionaty[value];
            dictionaty[value] = temp;
        }
    }
}

