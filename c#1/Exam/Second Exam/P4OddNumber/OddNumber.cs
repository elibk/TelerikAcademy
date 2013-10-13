using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P4OddNumber
{
    class OddNumber
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            long[] numbers = new long[N];
            long[] freqency = new long[N];
            long oddNum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
                oddNum ^= numbers[i];                 
            }
            Console.WriteLine(oddNum);
        }
    }
}
//for (int i = 0; i < numbers.Length; i++)
//{
//    for (int freq = 0; freq < numbers.Length; freq++)
//    {
//        if (numbers [i] == numbers [freq])
//        {
//            freqency[i]++;
//        }
//    }

//}
//for (int i = 0; i < numbers.Length; i++)
//{
//    if (freqency[i] % 2 !=0)
//    {
//        Console.WriteLine(numbers [i]);
//        break;
//    }

//}