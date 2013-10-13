////
namespace H20VariationsOfElements
{
    using System;
    using System.Linq;

   public class VariationsOfElements
    {
        private static readonly int N = int.Parse(Console.ReadLine()),
                                    K = int.Parse(Console.ReadLine());

        private static readonly int[] Combinations = new int[K];

        private static void Variations(int index)
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
                for (int number = 1; number <= N; number++)
                {
                    Combinations[index] = number;
                    Variations(index + 1);
                }             
            }
        }

        private static void Main(string[] args)
        {
            int index = 0;
            Variations(index);          
        }
    }
}
