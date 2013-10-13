using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H24SortListOfWordsInAlphabeticalOrder
{
    class SortListOfWordsInAlphabeticalOrder
    {
        private static readonly List<string> SortedList = new List<string>();

        static void Main(string[] args)
        {
            string input = "hi how Hello what who how which zaAY";

            List<string> words = SortWords(input);

            foreach (var word in words)
            {
                Console.Write(word+" ");
            }
            Console.WriteLine();
        }

        private static List<string> SortWords(string sequence)
        {
           List<string> words = ConvertToSequenceOfIntegers(sequence);
           
           return QuickSort(words) ;
        }

        private static List<string> ConvertToSequenceOfIntegers(string sequence)
        {
            List<string> words = new List<string>();
            int count = new int();

            if (sequence.LastIndexOf(' ') == sequence.Length - 1)
            {
                sequence = sequence.Substring(0, sequence.Length - 1);
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == ' ')
                {
                    words.Add(sequence.Substring(i - count, count));
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            words.Add(sequence.Substring((sequence.Length) - count, count));
            count = 0;

            return words;
        }

        private static List<string> QuickSort(List<string> stringList)
        {
            string pivot = string.Empty;

            if (stringList.Count <= 1)
            {
                SortedList.AddRange(stringList);

                return SortedList;
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

                QuickSort(less);
                SortedList.Add(pivot);
                QuickSort(greater);

                return SortedList;
            }
        }
    }
}
