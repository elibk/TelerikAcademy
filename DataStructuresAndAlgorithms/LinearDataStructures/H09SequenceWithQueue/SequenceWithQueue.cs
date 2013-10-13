////
namespace H09SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class SequenceWithQueue
    {
       public static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();
            int elemntsCount = 50;
            int firstMember = 2;
            sequence.Enqueue(firstMember);
            int index = 1;
            Console.WriteLine("Element {0} : {1}", index++, 2);
            while (index <= elemntsCount)
            {
                int currentSum = sequence.Dequeue();
                Console.WriteLine("Element {0} : {1}", index++, currentSum + 1);
                sequence.Enqueue(currentSum + 1);
                if (index > elemntsCount)
                {
                    break;
                }

                Console.WriteLine("Element {0} : {1}", index++, (2 * currentSum) + 1);
                sequence.Enqueue((2 * currentSum) + 1);
                if (index > elemntsCount)
                {
                    break;
                }

                Console.WriteLine("Element {0} : {1}", index++, currentSum + 2);
                sequence.Enqueue(currentSum + 2);
            }
        }
    }
}
