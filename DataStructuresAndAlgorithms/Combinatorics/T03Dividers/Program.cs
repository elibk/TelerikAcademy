using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03Dividers
{
    class Program
    {
       static int answer = 0;
       static int dividersCount = int.MaxValue;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[] set = new int[n];

            for (int i = 0; i < n; i++)
            {
                set[i] = int.Parse(Console.ReadLine());
            }

            
            int[] currentCombination = new int[n];
            bool[] used = new bool[n];
            int index = 0;

            GeneratePermutation(set, currentCombination, used, n, index);

            Console.WriteLine(answer);
        }

        private static void GeneratePermutation(int[] set, int[] currentCombination, bool[] used, int n, int index)
        {
            if (index >= n)
            {
                CheckDividers(currentCombination);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    currentCombination[index] = set[i];
                    GeneratePermutation(set, currentCombination, used, n, index + 1);
                    used[i] = false;
                }
            }
        }

        private static void CheckDividers(int[] currentCombination)
        {
            string currentNumberStr = String.Join(string.Empty, currentCombination);

            StringBuilder currentNumberModified = new StringBuilder();
           
            for (int i = 0; i < currentNumberStr.Length; i++)
            {
                if (currentNumberStr[i] != '0')
                {
                    for (int j = i; j < currentNumberStr.Length; j++)
                    {
                        currentNumberModified.Append(currentNumberStr[j]);
                    }

                    break;
                }
            }

            int currentNumber = int.Parse(currentNumberModified.ToString());
            int currentNumberDividersCount = 0;
            for (int i = 1; i <= currentNumber; i++)
            {
                if (currentNumber % i == 0)
                {
                    currentNumberDividersCount++;
                    if (currentNumberDividersCount > dividersCount)
                    {
                        break;
                    }
                }
            }

            if (currentNumberDividersCount < dividersCount)
            {
                dividersCount = currentNumberDividersCount;
                answer = currentNumber;
            }
            else if (currentNumberDividersCount == dividersCount)
            {
                if (currentNumber < answer)
                {
                    answer = currentNumber;
                }
            }
            
        }
    }
}
