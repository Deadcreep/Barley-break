using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    static class RandomGenerator
    {
        public static void Shuffle<T>(this Random rng, ref T[,] array)
        {
            int sideLength = Convert.ToInt32(Math.Sqrt(array.Length));
            int n = array.Length;
            while (n > 0)
            {   
                //int k = rng.Next(n--);
                //T temp = array[n];
                //array[n] = array[k];
                //array[k] = temp;
                
                int k = rng.Next(n--);
                int lastY = n % sideLength;
                int lastX = (n - lastY) / sideLength;
                int newY = k % sideLength;
                int newX = (k - newY) / sideLength;
                
                T temp = array[lastX, lastY];
                array[lastX, lastY] = array[newX, newY];
                array[newX, newY] = temp;
            }
        }
    }
}
