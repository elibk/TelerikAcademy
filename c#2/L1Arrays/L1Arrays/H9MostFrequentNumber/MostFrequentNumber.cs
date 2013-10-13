////
namespace H9MostFrequentNumber
{
    using System;
    using System.Linq;

    public class MostFrequentNumber
    {
        private static void Main(string[] args)
        {
            int[] array = { 5, 7, 7, 5, 3, 3, 2, 1, 1, 2 };

           Array.Sort(array);

            int maxLen = 0,
                currentLen = 1,
                mostCommonNum = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    currentLen++;
                }
                else
                {
                    if (maxLen < currentLen)
                    {
                        mostCommonNum = array[i];
                        maxLen = currentLen;
                    }
                    else if (maxLen == currentLen && maxLen > 1)
                    {
                        Console.WriteLine("{0} ({1} times).", array[i], maxLen);
                    }

                    currentLen = 1;
                }
            }

            if (maxLen < currentLen)
            {
                mostCommonNum = array[array.Length - 1];
                maxLen = currentLen;
            }
            else if (maxLen == currentLen && maxLen > 1)
            {
                Console.WriteLine("{0} ({1} times).", array[array.Length - 1], maxLen);
            }

            Console.WriteLine("{0} ({1} times).", mostCommonNum, maxLen);
        }
    }
}
