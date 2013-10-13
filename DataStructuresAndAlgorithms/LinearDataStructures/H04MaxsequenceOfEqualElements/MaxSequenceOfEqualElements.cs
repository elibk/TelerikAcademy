////
namespace H04MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class MaxSequenceOfEqualElements
    {
       public static void Main(string[] args)
       {
           // Press 'Enter' to stop the input
            List<int> numbers = new List<int>();

            do
            {
                try
                {
                    int number = ReadInput();
                    numbers.Add(number);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            } 
            while (true);

            DisplayCollection(GetMaxSequenceOfEqualElements(numbers));
        }

        public static List<int> GetMaxSequenceOfEqualElements(List<int> sequence)
        {
            if (sequence.Count == null)
            {
                throw new ArgumentNullException("Can not find sequance of equal elemnts in null.");
            }

            if (sequence.Count == 0)
            {
                throw new ArgumentException("Can not find sequance of equal elemnts in empty collection.");
            }

            int matchingElement = sequence[0];
            int countOfEqualElements = 1;
            int currentCount = 1;
            int currentElement = sequence[0];

            for (int i = 1; i < sequence.Count; i++)
            {
                if (currentElement != sequence[i])
                {
                    currentCount = 0;
                    currentElement = sequence[i];
                }

                currentCount++;

                if (currentCount > countOfEqualElements)
                {
                    countOfEqualElements = currentCount;
                    matchingElement = currentElement;
                }
            }

            List<int> sequanceOfEqual = new List<int>();

            for (int i = 0; i < countOfEqualElements; i++)
            {
                sequanceOfEqual.Add(matchingElement);
            }

            return sequanceOfEqual;
        }

        private static void DisplayCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static int ReadInput()
        {
            string input = Console.ReadLine();

            if (input == null || input == string.Empty)
            {
                throw new OperationCanceledException("End of input");
            }

            int number;
            if (!int.TryParse(input, out number))
            {
                throw new ArgumentOutOfRangeException(string.Format("The input must be a number between {0} and {1}.", int.MinValue, int.MaxValue));
            }

            return number;
        }
    }
}
