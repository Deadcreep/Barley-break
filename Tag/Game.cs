using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{

    struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Game
    {
        int[,] coordinates;
        public int Size { get; private set; }

        public Game(int size)
        {
            this.Size = size;
            FillField(size);
        }

        private void FillField(int size)
        {

            coordinates = new int[size, size];
            int arraySize = size * size;
            int[] array = new int[arraySize];
            for (int j = 0; j < arraySize; j++)
            {
                array[j] = j;
            }
            new Random().Shuffle<int>(ref array);
            int i = 0;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    coordinates[x, y] = array[i] == 16 ? 0 : array[i];
                    i++;
                }
        }


        public int this[int x, int y]
        {
            get
            {
                if (x >= Size || y >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                return coordinates[x, y];
            }
            set
            {
                coordinates[x, y] = value;
            }
        }

        public Coordinate GetLocation(int value)
        {
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    if (value == coordinates[x, y])
                    {
                        return new Coordinate
                        {
                            X = x,
                            Y = y
                        };
                    }

            throw new ArgumentException("Value does not exist");
        }

        public void Shift(int value)
        {
            if (value == 0)
            {
                throw new ArgumentException("Incorrect value");
            }
            var source = GetLocation(value);
            var dest = GetLocation(0);
            if (Math.Abs(source.X + source.Y - dest.X - dest.Y) != 1)
                throw new Exception("Can't move " + value);
            coordinates[source.X, source.Y] = 0;
            coordinates[dest.X, dest.Y] = value;
        }
        public bool IsCompleted()
        {
            int val = 0;
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                {
                    if (coordinates[x, y] != val)
                        return false;
                    val++;
                }
            return true;
        }
    }
}

