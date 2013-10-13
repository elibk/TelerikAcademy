////

namespace H08ArrayMajorants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayMajorant
    {
        public static void Main(string[] args)
        {
            // Press 'Enter' to stop the input
            List<int> numbers = new List<int> { 1, -2, 1, 4, 1, -2, 4, 1, 1 };
            
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

            var majorants = GetMajorantNumbers(numbers);
            Console.WriteLine("Majorant for the collection is every number that occures at least {0} times.", (numbers.Count() / 2) + 1);
            DisplayCollection(majorants);
        }

        private static IEnumerable<T> GetMajorantNumbers<T>(IEnumerable<T> elements)
        {
            List<T> majorant = new List<T>();
            Stack<T> comaparer = new Stack<T>();

            foreach (var element in elements)
            {
                if (comaparer.Count == 0)
                {
                    comaparer.Push(element);
                }
                else if (!comaparer.Peek().Equals(element))
                {
                    comaparer.Pop();
                }
            }

            int majorantCount = (elements.Count() / 2) + 1;
            int count = 0;
            T candidate = default(T);
            if (comaparer.Count > 0)
            {
                candidate = comaparer.Pop();

                foreach (var element in elements)
                {
                    if (element.Equals(candidate))
                    {
                        count++;
                    }
                }
            }

            if (count == majorantCount)
            {
                majorant.Add(candidate);
            }

            return majorant;
        }

        private static void DisplayCollection<T>(IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                Console.WriteLine("The is no majorants.");
            }

            foreach (var item in collection)
            {
                Console.WriteLine("Majorant -> {0}.", item);
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
