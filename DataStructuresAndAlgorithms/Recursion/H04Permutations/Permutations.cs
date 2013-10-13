using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H04Permutations
{
    class Permutations
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[] combination = new int[n];
            bool[] used = new bool[n];
            SimulateLoops(combination, used, n, 0);
        }

        private static void SimulateLoops(int[] combinations, bool[] used, int n, int index)
        {
            if (index >= n)
            {
                foreach (var item in combinations)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    combinations[index] = i + 1;
                    SimulateLoops(combinations, used, n, index + 1);
                    used[i] = false;
                }
               
            }

        }
    }
}
