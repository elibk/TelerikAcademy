using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class ZerosAtTheEndOfFactorial
{
    static void Main()
    {
        char digit;
        int sum = 0;
        Console.Write("Enter natural number:");
        int num = int.Parse(Console.ReadLine());
        BigInteger factorial = 1; 

        for (int i = 2; i <= num; i++)
        {
            factorial = factorial * i;            
        }
        string factorialToString = Convert.ToString(factorial);

        for (int i = factorialToString.Length - 1; i > 0; i--)
        {
            digit = factorialToString[i];
            if (digit != '0')
            {
                break;
            }
            else
            {
                sum++;
            }
        }
        Console.WriteLine("{0}! is {1}.",num,factorial);
        switch (sum)
        {
            case 0:
                Console.WriteLine("There are no zeros in the end of {0}!.",num);
                break;
            case 1:
                Console.WriteLine("There is {0} zero at the end of {1}!.", sum, num);
                break;
            default:
                Console.WriteLine("There are {0} zeros at the end of {1}!.",sum,num);
                break;
        }
    }
}
