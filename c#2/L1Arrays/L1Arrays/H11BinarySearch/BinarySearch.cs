////
namespace H11BinarySearch
{
    using System;
    using System.Linq;

    public class BinarySearch
    {
        private static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 5, 6, 7, 8, 10, 11, 12, 15, 16, 17, 18, 20, 21 };

            Console.Write("Enter number:");
            int number = int.Parse(Console.ReadLine()),

                arrayMiddle = array.Length / 2,
                arrayStart = 0,
                arrayEnd = array.Length - 1,
                arrayLen = array.Length;

            while (arrayStart != arrayEnd)
            {
                if (array[arrayMiddle] < number)
                {
                    arrayStart = arrayMiddle + 1;
                }
                else if (array[arrayMiddle] > number)
                {
                    arrayEnd = arrayMiddle - 1;
                }
                else
                {
                    break;  
                }

                arrayLen = arrayStart + arrayEnd + 1;
                arrayMiddle = arrayLen / 2;
            }
            if (arrayStart == arrayEnd)
            {
                if (array[arrayMiddle] == number)
                {
                    Console.WriteLine("Found under index:" + arrayMiddle);
                }
                else
                {
                    Console.WriteLine("Not found in the array.");
                }
            }
            else
            {
                Console.WriteLine("Found under index:" + arrayMiddle);
            }
        }
    }
}
