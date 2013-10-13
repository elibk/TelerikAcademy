using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H05VariationsWithDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            string[] set = new string[]{"hi", "a", "b"};
            string[] variation = new string[k];
            GetVariations(set, variation, n, k, 0);
        }

        private static void GetVariations(string[] set, string[] variations, int n,int k, int index)
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

            for (int i = 0; i < n; i++)
            {
                variations[index] = set[i];
                GetVariations(set, variations, n, k, index + 1);
            }

        }
    }
}
