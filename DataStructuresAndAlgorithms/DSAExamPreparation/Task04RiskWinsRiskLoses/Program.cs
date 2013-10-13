using System;
using System.Collections.Generic;
using System.Linq;

namespace Task04RiskWinsRiskLoses
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialState = Console.ReadLine();
            string finalState = Console.ReadLine();

            int forbidenCombinationsCount = int.Parse(Console.ReadLine());
            HashSet<string> forbidenCombinations = new HashSet<string>();
            for (int i = 0; i < forbidenCombinationsCount; i++)
            {
                forbidenCombinations.Add(Console.ReadLine());
            }

            var count = 0;
            for (var i = 0; i < 5; i++)
            {
                var startPos = initialState[i] - '0';
                var endPos = finalState[i] - '0';

                count += Math.Min(Math.Abs(startPos - endPos), 10 - Math.Abs(startPos - endPos));
            }
            Console.WriteLine(count);

            //Console.WriteLine(-1);
        }
    }
}
