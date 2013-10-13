////
namespace H05SortsArrayByTheLengthOfItsElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class SortsArrayByTheLengthOfItsElements
    {
        private readonly static List<string> sortedList = new List<string>();

        private static void Sort(List<string> stringList)
        {
            string pivot = string.Empty;

            if (stringList.Count <= 1)
            {
                sortedList.AddRange(stringList);

                return;
            }
            else
            {
                pivot = stringList[stringList.Count / 2];
                stringList.Remove(pivot);
                List<string> less = new List<string>();
                List<string> greater = new List<string>();

                for (int i = stringList.Count - 1; i >= 0; i--)
                {                   
                    if (stringList[i].Length > pivot.Length)
                    {
                        greater.Add(stringList[i]);
                    }
                    else
                    {
                        less.Add(stringList[i]);
                    }
                }

                Sort(less);
                sortedList.Add(pivot);
                Sort(greater);
            }
        }

       private static void Print(List<string> sortedList)
        {
            foreach (var item in sortedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

       private static void Main(string[] args)
        {
            List<string> array = new List<string>() { "bc", "abcd", "c", "abd", "ad", "abc" };
            Sort(array);

            Print(array);
            Print(sortedList);
        }
    }
}
