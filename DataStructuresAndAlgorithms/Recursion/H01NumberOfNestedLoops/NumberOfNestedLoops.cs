using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H01NumberOfNestedLoops
{
    class NumberOfNestedLoops
    {
        
        static void Main(string[] args)
        {
            int n = 3;
            int[] combination = new int[n];
            SimulateLoops(combination, n, 0);
        }

        private static void SimulateLoops(int[] combinations, int n, int index)
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

            for (int i = 1; i <= n; i++)
            {
                combinations[index] = i;
                SimulateLoops(combinations, n, index + 1);
            }
          
        }
    }
}
