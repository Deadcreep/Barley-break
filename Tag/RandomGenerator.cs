using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    static class RandomGenerator
    {
        public static void Shuffle<T>(this Random rng, ref T[] array)
        {
            int n = array.Length;
            while (n > 0)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
