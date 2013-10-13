////
namespace H14QuickSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuickSort
    {
        private static readonly List<string> SortedList = new List<string>();

        private static void Sorting(List<string> stringList)
        {
            string pivot = string.Empty;
            
            if (stringList.Count <= 1)
            {
                SortedList.AddRange(stringList);
                
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
                    int result = string.Compare(stringList[i], pivot, StringComparison.CurrentCultureIgnoreCase);
                    if (result == 1)
                    {
                        greater.Add(stringList[i]);
                    }
                    else
                    {
                        less.Add(stringList[i]);
                    }
                }

                Sorting(less);         
                SortedList.Add(pivot);
                Sorting(greater);
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
            Sorting(array);

            Print(array);
            Print(SortedList);
        }

        ////solution for integers
        ////static List<int> sortedList = new List<int>();

        ////static void Sorting(List<int> intList)
        ////{
        ////    int pivot = new int();

        ////    if (intList.Count <= 1)
        ////    {
        ////        sortedList.AddRange(intList);

        ////        return;
        ////    }
        ////    else
        ////    {
        ////        pivot = intList[intList.Count / 2];
        ////        intList.Remove(pivot);
        ////        List<int> less = new List<int>();
        ////        List<int> greater = new List<int>();

        ////        for (int i = intList.Count - 1; i >= 0; i--)
        ////        {
        ////            if (intList[i] > pivot)
        ////            {
        ////                greater.Add(intList[i]);
        ////            }
        ////            else if (intList[i] <= pivot)
        ////            {
        ////                less.Add(intList[i]);
        ////            }
        ////        }

        ////        Sorting(less);
        ////        sortedList.Add(pivot);
        ////        Sorting(greater);
        ////    }
        ////}

        ////static void Print(List<int> sortedList)
        ////{
        ////    foreach (var item in sortedList)
        ////    {
        ////        Console.Write(item + " ");
        ////    }
        ////    Console.WriteLine();
        ////}

        ////static void Main(string[] args)
        ////{
        ////    List<int> arr = new List<int>() { -5, 5, 7, 8, 9, -5, 5, 6, -5 };
        ////    Sorting(arr);
        ////    Print(sortedList);
        ////}
    }
}
