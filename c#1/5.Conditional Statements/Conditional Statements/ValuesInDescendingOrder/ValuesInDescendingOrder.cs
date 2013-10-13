using System;

class ValuesInDescendingOrder
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter three numbers:");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        if (firstNum > secondNum && thirdNum < secondNum)
        {
            Console.WriteLine("The Numbers In Descending Order are {0},{1} and {2}", firstNum, secondNum, thirdNum);
        }
        if (firstNum > secondNum && thirdNum > secondNum)
        {
            if (firstNum>thirdNum)
            {
                Console.WriteLine("The Numbers In Descending Order are {0},{1} and {2}", firstNum, thirdNum, secondNum);
            }
            if (firstNum<thirdNum)
            {
                Console.WriteLine("The Numbers In Descending Order are {0},{1} and {2}", thirdNum, firstNum, secondNum);
            }   
        }
        if (secondNum > firstNum && thirdNum < firstNum)
        {
            Console.WriteLine("The Numbers In Descending Order are {0},{1} and {2}", secondNum, firstNum, thirdNum);
        }
        if (secondNum > firstNum && thirdNum > firstNum)
        {
            if (secondNum > thirdNum)
            {
                Console.WriteLine("The Numbers In Descending Order are {0},{1} and {2}", secondNum, thirdNum, firstNum);
            }
            if (secondNum < thirdNum)
            {
                Console.WriteLine("The Numbers In Descending Order are {0},{1} and {2}", thirdNum, secondNum, firstNum);
            }
        }

    }
}
