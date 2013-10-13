using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T05ZizZagLines
{
    class Program
    {
        static bool[] used;
        static int[] variation;
        static ulong zigZagVariationsCount = 0;

        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(' ');

            int n = int.Parse(data[0]);
            int k = int.Parse(data[1]);
            used = new bool[n];
            variation = new int[k];

            GetVariationsEvenK(n, k, 0);
            Console.WriteLine(zigZagVariationsCount);
        }

        private static void GetVariationsEvenK(int n, int k, int index)
        {
            if (index >= k)
            {
               
                    zigZagVariationsCount++;
                

                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variation[index] = i;
                    if (IsVariationZigZagTillNow(index))
                    {
                        GetVariationsEvenK(n, k, index + 1);
                    }
                    used[i] = false;
                }

            }
        }

        private static bool IsVariationZigZag()
        {
            int current = variation[0];
            for (int i = 1; i < variation.Length; i++)
            {
                if (i % 2 == 1)
                {
                    if (current <= variation[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (current >= variation[i])
                    {
                        return false;
                    }
                }

                current = variation[i];
            }

            return true;
        }

        private static bool IsVariationZigZagTillNow(int index)
        {
            int current = variation[0];
            for (int i = 1; i <= index; i++)
            {
                if (i % 2 == 1)
                {
                    if (current <= variation[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (current >= variation[i])
                    {
                        return false;
                    }
                }

                current = variation[i];
            }

            return true;
        }
    }
}
