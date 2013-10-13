////
namespace H4MaximalSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class MaximalSequenceOfEqualElements
    {
       private static void Main(string[] args)
        {
            int[] array = { 9, 8, 6, 6, 5, 9, 9, 9 };

            int maxLen = 2,
                currentLen = 1,
                mostCommonNum = 0;
            bool equalness = false;

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
                        equalness = true;
                        for (int ind = 0; ind < maxLen; ind++)
                        {
                            Console.Write(array[i] + ";");
                        }

                        Console.WriteLine();
                    }
                    
                    currentLen = 1;
                }
            }

            if (maxLen < currentLen)
            {
                mostCommonNum = array[array.Length - 1];
                maxLen = currentLen;
            }
            else if (maxLen == currentLen && mostCommonNum != array[array.Length - 1])
            {
                equalness = true;
                for (int ind = 0; ind < maxLen; ind++)
                {
                    Console.Write(array[array.Length - 1] + ";");
                }

                Console.WriteLine();
            }

            if (equalness == false)
            {
                Console.WriteLine("There aren't any sequences of equal elements.");
            }
        }
    }
}
