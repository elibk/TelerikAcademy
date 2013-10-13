////
namespace TestGenerics
{
    using System;
    using System.Linq;
    using JustGenerics;   

   public class Test
    {
       private static void Main(string[] args)
        {
            GenericList<int> someList = new GenericList<int>(2);

            someList.AddElement(0);
            someList.AddElement(1);
            someList.AddElement(2);
            someList.AddElement(3);
            someList.AddElement(4);
            someList.RemoveElement(3);
            someList.InsertElement(0, 123);

            ////someList.Capacity = 1;

            Console.WriteLine(someList[0]);
            Console.WriteLine(new string('-', Console.WindowWidth));
            for (int i = 0; i < someList.Count; i++)
            {
                Console.WriteLine(someList[i]);
            }

            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.WriteLine(someList.FindElement(124)); 
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.WriteLine(someList.Min());
            Console.WriteLine(someList.Max());
        }
    }
}
