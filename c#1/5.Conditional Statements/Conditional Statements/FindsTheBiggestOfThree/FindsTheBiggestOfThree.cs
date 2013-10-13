using System;
class FindsTheBiggestOfThree
{
    static void Main()
    {
        Console.WriteLine("Enter three diffrent numbers:");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine()); 

        if (firstNum > secondNum && thirdNum < secondNum)
        {
            Console.WriteLine("{0} is the biggest number",firstNum);
        }
        if (firstNum > secondNum && thirdNum > secondNum)
        {
            if (firstNum>thirdNum)
            {
                Console.WriteLine("{0} is the biggest number", firstNum);
            }
            if (firstNum<thirdNum)
            {
                Console.WriteLine("{0} is the biggest number", thirdNum);
            }   
        }
        if (secondNum > firstNum && thirdNum < firstNum)
        {
            Console.WriteLine("{0} is the biggest number", secondNum);
        }
        if (secondNum > firstNum && thirdNum > firstNum)
        {
            if (secondNum > thirdNum)
            {
                Console.WriteLine("{0} is the biggest number", secondNum);
            }
            if (secondNum < thirdNum)
            {
                Console.WriteLine("{0} is the biggest number", thirdNum);
            }
        }
    }
}

