////
namespace H05H06ElementBiggerThnaItsNeighbors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class H05
    {
        public static void GetBigger(int[] array)
        {
            List<int> biggerElements = new List<int> { };
            List<int> biggerElementsindexes = new List<int> { };

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0 && i < array.Length - 1)
                {
                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    {
                        biggerElements.Add(array[i]);
                        biggerElementsindexes.Add(i);
                    }
                }
                else if (i == 0 && i < array.Length - 1)
                {
                    if (array[i] > array[i + 1])
                    {
                        biggerElements.Add(array[i]);
                        biggerElementsindexes.Add(i);
                    }
                }
                else if (i == array.Length - 1 && i > 0)
                {
                    if (array[i] > array[i - 1])
                    {
                        biggerElements.Add(array[i]);
                        biggerElementsindexes.Add(i);
                    }
                }
            }

            PrintList(biggerElements);
            H06 getIndex = new H06();        
            Console.WriteLine(getIndex.GetFirstBiggerIndex(biggerElementsindexes));
        }

        private static void PrintList(List<int> list) 
        {
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

            GetBigger(array);
        }
    }
}
