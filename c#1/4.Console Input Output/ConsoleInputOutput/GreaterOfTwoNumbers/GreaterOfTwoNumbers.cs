using System;

class GreaterOfTwoNumbers
{
    static void Main()
    {
        Console.Write("Enter first integer number:");
        int firstNum = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second integer number:");
        int secondNum = Convert.ToInt32(Console.ReadLine());
        while (firstNum>secondNum)
        {
            Console.WriteLine("{0} is grater number.",firstNum);
            break;
        }
        while (firstNum< secondNum)
        {
            Console.WriteLine("{0} is grater number.",secondNum);
            break;
        }
    }
}
