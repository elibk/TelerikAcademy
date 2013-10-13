////
namespace H03LoopRefactorer
{
    using System;
    using System.Linq;

   internal class TheDevilLoop
    {
        private const int ExpectedValue = 8;
       
        private static void Main(string[] args)
        {
            int[] array = new int[100];

            bool devilWord = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 10 == 0)
                {
                    devilWord = IsExpectedValue(array[i]);
                }
                
                Console.WriteLine(array[i]);
            }
            //// More code here
            if (devilWord)
            {
                Console.WriteLine("the devil has spoken: Value Found");
            }
        }

        private static bool IsExpectedValue(int valueForCheck)
        {
            if (valueForCheck == ExpectedValue)
            {
                return true;
            }

            return false;
        }
    }
}
