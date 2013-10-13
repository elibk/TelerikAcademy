////
namespace H03ComparesArraysLexicographically
{
    using System;
    using System.Linq;

    public class ComparesArraysLexicographically
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter first array lenght:");
            char[] firstArray = new char[int.Parse(Console.ReadLine())];
            string firstA = string.Empty,
                   secondA = string.Empty;

            Console.Write("Enter second array lenght:");
            char[] secondArray = new char[int.Parse(Console.ReadLine())];

            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write("Enter letter in position {0} in first array:", i);
                firstArray[i] = char.Parse(Console.ReadLine());
                firstA += firstArray[i];
            }

            Console.WriteLine();
            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write("Enter letter in position {0} in second array:", i);
                secondArray[i] = char.Parse(Console.ReadLine());
                secondA += secondArray[i];
            }

            int result = string.Compare(firstA, secondA, StringComparison.CurrentCultureIgnoreCase);

            if (result == -1)
            {
                Console.WriteLine("First array is in fisrt position lexicographically.");
            }
            else if (result == 1)
            {
                Console.WriteLine("Second array is in fisrt position lexicographically.");
            }
            else
            {
                Console.WriteLine("The arrays are equal by lexicographically order.");
            }
        }
    }
}
