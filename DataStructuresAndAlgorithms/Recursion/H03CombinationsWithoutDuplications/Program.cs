using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H03CombinationsWithoutDuplications
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            int[] combination = new int[k];
            SimulateLoops(combination, n, k, 0, 0);
        }

        private static void SimulateLoops(int[] combinations, int n, int k, int index, int start)
        {
            if (index >= k)
            {
                foreach (var item in combinations)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = start; i < n; i++)
            {
                combinations[index] = i + 1;
                SimulateLoops(combinations, n, k, index + 1, i + 1);
            }

        }
    }
}
