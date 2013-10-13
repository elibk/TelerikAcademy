////
namespace H10ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class ShortestSequenceOfOperations
    {
       public static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();
            int searchedNumber = 16;
            int firstMember = 5;
            sequence.Enqueue(firstMember);
            int index = 1;
            Console.WriteLine("Element {0} : {1}", index++, 2);
            while (true)
            {
                int currentSum = sequence.Dequeue();
                
                currentSum += 1;
                Console.WriteLine("Element {0} : {1}", index++, currentSum);
                sequence.Enqueue(currentSum);
                if (currentSum == searchedNumber)
                {
                    break;
                }

                currentSum += 2;
                Console.WriteLine("Element {0} : {1}", index++, currentSum);
                sequence.Enqueue(currentSum);
                if (currentSum == searchedNumber)
                {
                    break;
                }

                currentSum *= 2;
                Console.WriteLine("Element {0} : {1}", index++, currentSum);
                sequence.Enqueue(currentSum);
                if (currentSum == searchedNumber)
                {
                    break;
                }
            }
        }
    }
}
