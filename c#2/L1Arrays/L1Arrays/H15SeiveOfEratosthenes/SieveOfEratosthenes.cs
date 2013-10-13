////
namespace H15SieveOfEratosthenes
{
    using System;
    using System.Linq;

    public class SieveOfEratosthenes
    {
        private static void Main(string[] args)
        {
            bool[] primes = new bool[10000];

            ////At the begining we say for every number "it's false that it can be divided". So all numbers are prime.

            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == false)
                {
                    for (int stepOfincracing = i + i; stepOfincracing < primes.Length; stepOfincracing += i)
                    {
                        primes[stepOfincracing] = true;
                    }
                }
            }
            //// priting prime numbers, those for which it's true, that "it's false that it can be divided"
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == false)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
