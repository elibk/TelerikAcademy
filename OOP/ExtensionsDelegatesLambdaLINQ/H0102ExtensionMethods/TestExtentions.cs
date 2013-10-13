////
namespace H0102ExtensionMethods
{
    using System;
    using System.Text;

   public class TestExtentions
    {
       private static void Main(string[] args)
        {
            StringBuilder someText = new StringBuilder("123456789");
            someText = someText.Substring(3, 11);
            Console.WriteLine(someText.ToString());

            someText = new StringBuilder("123456789");
            someText = someText.Substring(3);
            Console.WriteLine(someText.ToString());

            Console.WriteLine(new string('^', Console.WindowWidth));

            int[] array = 
            {
                1, 2, 3, 1, 2, 3, -1, 2, 3, 1, 
            };
            Console.WriteLine(array.Min());
            Console.WriteLine(array.Max());
            Console.WriteLine(array.Sum());
            Console.WriteLine(array.Average());
            Console.WriteLine(array.Product());
            Console.WriteLine(new string('^', Console.WindowWidth));
        }
    }
}
