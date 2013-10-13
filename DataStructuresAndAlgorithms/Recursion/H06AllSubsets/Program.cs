using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H06AllSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            string[] set = new string[] { "test", "rock", "fun" };
            bool[] setUsed = new bool[n];
            string[] variation = new string[k];
            GetVariations(set, variation, setUsed, n, k, 0,0);
        }

        private static void GetVariations(string[] set, string[] variations, bool[] setUsed, int n, int k, int index, int start)
        {
            if (index >= k)
            {
                foreach (var item in variations)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = start; i < n; i++)
            {

                variations[index] = set[i];
                GetVariations(set, variations, setUsed, n, k, index + 1, i + 1);
            }

        }
    }
}
