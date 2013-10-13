using System;

class ShowsTheSignOfTheProduct
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers:");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        if ((secondNum < 0) && (firstNum < 0 ^ thirdNum < 0))
        {
           Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"+\"",firstNum,secondNum,thirdNum);
        }
        if ((secondNum > 0) && (thirdNum < 0 && firstNum < 0))
        {
           Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"+\"",firstNum,secondNum,thirdNum);
        }
        if ((firstNum>0 && secondNum>0)&&(thirdNum>0))
        {
            Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"+\"",firstNum,secondNum,thirdNum);
        }
        if ((firstNum < 0) && (secondNum > 0 && thirdNum > 0))
        {
           Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"-\"",firstNum,secondNum,thirdNum);
        }
        if ((secondNum < 0) && (firstNum > 0 && thirdNum > 0))
        {
             Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"-\"",firstNum,secondNum,thirdNum);
        }
        if ((thirdNum < 0) && (secondNum > 0 && firstNum > 0))
        {
             Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"-\"",firstNum,secondNum,thirdNum);
        }
        if ((firstNum < 0 && secondNum < 0) && (thirdNum < 0))
        {
            Console.WriteLine("The sign of the product of {0} , {1} and {2} is \"-\"",firstNum,secondNum,thirdNum);
        }
        if ((firstNum == 0 || secondNum == 0)||(thirdNum == 0))
        {
           Console.WriteLine("The sign of the product of {0} , {1} and {2} is doesn't metter, becouse the product is 0 .",firstNum,secondNum,thirdNum);
        }
 
    }
}

