using System;

class TheGratestOfFive
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers:");
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());
        int fourthNum = int.Parse(Console.ReadLine());
        int fifthNum = int.Parse(Console.ReadLine());
        int biggestNum = firstNum;

        if (biggestNum < secondNum)
        {
            biggestNum = secondNum;
        }
        if (biggestNum < thirdNum)
        {
            biggestNum = thirdNum;
        }
        if (biggestNum < fourthNum)
        {
            biggestNum = fourthNum;
        }
        if (biggestNum < fifthNum)
        {
            biggestNum = fifthNum;
        }

        Console.WriteLine("The gratest number is {0}.",biggestNum);
    }
}
