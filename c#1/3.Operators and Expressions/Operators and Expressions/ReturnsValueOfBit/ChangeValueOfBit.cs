
using System;

class ChangeValueOfBit
    {
        static void Main()
        {
            Console.WriteLine(
                "Let's play with bits. \nEnter a number and look what will happen if we change only one of\nthis little buddies :) :");
            int num = int.Parse(Console.ReadLine()); ;
            Console.Write("This is {0} binary representation: ", num);
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
            int changedNum;
            int position = 31;
            int one = 1 << position;
            if (num < 0)
            {
                changedNum = num ^ one;
                Console.Write("We changed last bit and now in binary representation the number looks like this:");
                Console.WriteLine(Convert.ToString(changedNum, 2).PadLeft(32, '0'));
                Console.WriteLine("And this is num now:{0}",changedNum);
            }
            else
            {
                changedNum = num | one;
                Console.Write("We changed last bit and now in binary representation the number looks like this:");
                Console.WriteLine(Convert.ToString(changedNum, 2).PadLeft(32, '0'));
                Console.WriteLine("And this is num now:{0}", changedNum);
            }
        }
    }
