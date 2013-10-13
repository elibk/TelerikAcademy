namespace H02ElementsWithOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ElementsWithOddOccurrences
    {
        public static void Main(string[] args)
        {
            string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" }; 

            IEnumerable<string> numbersAndOccurrences = GetElementsAndWithOddOccurrences(array);
            DisplayResult(numbersAndOccurrences);
        }

        private static void DisplayResult(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                Console.Write(" {0} ", word);
            }

            Console.WriteLine();
        }

        private static string[] GetElementsAndWithOddOccurrences(string[] numbers)
        {
            IDictionary<string, int> numbersAndOccurrences = new Dictionary<string, int>();
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbersAndOccurrences.ContainsKey(numbers[i]))
                {
                    numbersAndOccurrences.Add(numbers[i], 0);
                }

                numbersAndOccurrences[numbers[i]]++;
            }

            var oddOcurredNumbersDict = numbersAndOccurrences.Where(number => number.Value % 2 != 0);

            string[] oddOcurredElements = new string[oddOcurredNumbersDict.Count()];

            int index = 0;

            foreach (var item in oddOcurredNumbersDict)
            {
                oddOcurredElements[index++] = item.Key;
            }

            return oddOcurredElements;
        }
    }
}
