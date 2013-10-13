using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace T04RowOfColoredBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            string initCombination = Console.ReadLine();
            BigInteger n = initCombination.Length;
            BigInteger divider = 1;
            Dictionary<char, BigInteger> colorOccurence = new Dictionary<char, BigInteger>();
           

            for (int i = 0; i < initCombination.Length; i++)
            {
                if (!colorOccurence.ContainsKey(initCombination[i]))
                {
                    colorOccurence.Add(initCombination[i], 0);
                }

                colorOccurence[initCombination[i]]++;
            }

            foreach (var item in colorOccurence)
            {
                divider *= GetFactoriel(item.Value);
            }

           Console.WriteLine(GetFactoriel(n)/ divider);

           
        }

        private static BigInteger GetFactoriel(BigInteger number) 
        {
            BigInteger factoriel = 1;

            for (BigInteger i = 2; i <= number; i++)
            {
                factoriel *= i;
            }

            return factoriel;
        }
    }
}
