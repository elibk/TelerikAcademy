////
namespace H21CombinationsOfDistinctElements
{
    using System;
    using System.Linq;

    public class CombinationsOfDistinctElements
    {
        private static readonly int N = int.Parse(Console.ReadLine()),
                                    K = int.Parse(Console.ReadLine());

        private static readonly int[] Combinations = new int[K];
        
        private static void DistinctElemnts(int index, int nextIndex)
        {
            if (index == K)
            {
                Console.Write("{");
                foreach (var item in Combinations)
                {
                    Console.Write(item);
                }

                Console.WriteLine("}");
            }
            else
            {
                for (int i = nextIndex; i <= N; i++)
                {           
                    Combinations[index] = i;
                    DistinctElemnts(index + 1, i + 1);
                }             
            }
        }

        private static void Main(string[] args)
        {
            int index = 0,
                nextIndex = 1;

            DistinctElemnts(index, nextIndex);   
        }
    }
}
