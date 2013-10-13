//We are given an array of integers and a number S. 
//Write a program to find if there exists a subset of the elements of the array that has a sum S.
//Example:arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H16SubsetSum
{
    class SubsetSum
    {
        static void Main(string[] args)
        {
            int S = int.Parse(Console.ReadLine());
            //int N = int.Parse(Console.ReadLine());
            int[] numbers = {2, 1, 2, 4, 3, 5, 2, 6};
            int sum = new int { };
            int count = new int { };
            bool notFound = true;

            //bits
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numbers[i] = int.Parse(Console.ReadLine());
            //}


            for (int i = 1, max = (int)(Math.Pow(2, numbers.Length)); i < max; i++)
            {
                sum = 0;
                List<int> intList = new List<int>();
                for (int position = 0; position < numbers.Length; position++)
                {
                    int mask = i & (1 << position);
                    int bit = mask >> position;
                    if (bit == 1)
                    {
                        sum += numbers[position];
                        intList.Add(numbers[position]);
                    }
                }
                if (sum == S)
                {
                    notFound = false;

                    Console.Write("Yes -->( ");
                    foreach (var item in intList)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine(")");
                    break;
                }

            }
            if (notFound)
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
