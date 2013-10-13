using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Tribonacci
{
    static void Main()
    {
        BigInteger[] numbers = new BigInteger[4];

        for (int i = 0; i < numbers.Length -1; i++)
        {
            numbers[i] = BigInteger.Parse(Console.ReadLine());
        }
        int N = int.Parse(Console.ReadLine());
        if (N>3)
        {
            for (int i = 4; i <= N; i++)
	    {
	        numbers[3] = numbers[0] + numbers[1] + numbers[2];
            numbers[0] = numbers[1]; 
            numbers[1] = numbers[2]; 
            numbers[2] = numbers[3];
	    }
        Console.WriteLine(numbers[3]); 
        }
        else if (N == 3)
        {
            Console.WriteLine(numbers[2]);
        }
        else if (N == 2)
        {
            Console.WriteLine(numbers[1]);
        }
        else if (N == 1)
        {
            Console.WriteLine(numbers[0]);
        }  
    }
}