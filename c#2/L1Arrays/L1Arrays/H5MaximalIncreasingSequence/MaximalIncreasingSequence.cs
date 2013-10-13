////
namespace H5MaximalIncreasingSequence
{
    using System;
    using System.Linq;

    public class MaximalIncreasingSequence
    {
        private static void Main(string[] args)
        {
            int[] array = { 9, 8, 7, 6, 5, 4, 3, 2 };

            int maxLen = 2,
                currentLen = 1,
                mostIncreasingSeq = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    currentLen++;
                    if (mostIncreasingSeq < currentLen)
                    {
                        mostIncreasingSeq = currentLen;
                    }                
                }
                else
                {
                    currentLen = 1;
                }
            }

            currentLen = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    currentLen++;
                }
                else
                {
                    if (maxLen < currentLen && currentLen == mostIncreasingSeq)
                    {  
                        maxLen = currentLen;
                    }

                    if (maxLen == currentLen)
                    {
                        for (int ind = i - (maxLen - 1); ind <= i; ind++)
                        {
                            Console.Write(array[ind] + ";");
                        }

                        Console.WriteLine();
                    }

                    currentLen = 1;
                }
            }

            if (maxLen < currentLen)
            {
                maxLen = currentLen;
            }

            if (maxLen == currentLen)
            {
                for (int ind = (array.Length - 1) - (maxLen - 1); ind <= (array.Length - 1); ind++)
                {
                    Console.Write(array[ind] + ";");
                }

                Console.WriteLine();
            }
        }
    }
}
