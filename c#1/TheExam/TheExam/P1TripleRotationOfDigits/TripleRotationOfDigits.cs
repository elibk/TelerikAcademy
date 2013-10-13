using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1TripleRotationOfDigits
{
    class TripleRotationOfDigits
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int firstLenNum = num.Length - 1;
            char toAdd;

            for (int count = 0; count < 3; count++)
            {
                toAdd = num[num.Length - 1];
                num = num.Substring(0, num.Length - 1);

                if (toAdd != '0')
                {
                    num = toAdd + num;
                }
            }
            Console.WriteLine(num);
        }
    }
}