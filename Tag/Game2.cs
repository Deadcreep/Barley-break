using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game2 : Game, IPlayable
    {
        public Game2(params int[] list) : base(list)
        {
        }
        
        private List<int> FreezeBoard(int[,] knuckle)
        {
            List<int> oldValues = new List<int>();
            for (int x = 0; x < sideLength; x++)
            {
                for (int y = 0; y < sideLength; y++)
                {
                    oldValues.Add(this[x, y]);
                }
            }
            return oldValues;
        }

        public virtual void Randomize()
        {
            Random rng = new Random();
            var oldValues = FreezeBoard(knuckles);
            while (!RandomizeIsCompleted(oldValues))
            {
                var randomTemp = rng.Next(1, 5);
                var temp = GetLocation(0);
                Coordinate newCoordinate = new Coordinate();
                switch (randomTemp)
                {
                    case 1: //top
                        newCoordinate = new Coordinate(temp.x - 1, temp.y);
                        break;
                    case 2: //right
                        newCoordinate = new Coordinate(temp.x, temp.y + 1);
                        break;
                    case 3: //bottom
                        newCoordinate = new Coordinate(temp.x + 1, temp.y);
                        break;
                    case 4: //left
                        newCoordinate = new Coordinate(temp.x, temp.y - 1);
                        break;
                }
                if (CheckCoordinates(newCoordinate))
                {
                    Shift(this[newCoordinate.x, newCoordinate.y]);
                }
            }
        }

        private bool RandomizeIsCompleted(List<int> oldValues)
        {
            int step = 0;
            for (int x = 0; x < sideLength; x++)
            {
                for (int y = 0; y < sideLength; y++)
                {
                    if (knuckles[x, y] == oldValues[step])
                        return false;
                    step++;
                }
            }
            return true;
        }

        protected bool CheckCoordinates(Coordinate coordinate)
        {
            if (coordinate.x < 0 || coordinate.y < 0 || coordinate.x >= sideLength || coordinate.y >= sideLength)
                return false;
            return true;
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
