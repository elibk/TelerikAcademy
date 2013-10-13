//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
using System;

class first10
{
    static void Main()
    {
        int positiveNum = 0;
        int negativeNum = -1;
        int numToShow = 1;

        while (numToShow < 10)
        {
            positiveNum += 2;
            negativeNum = (positiveNum + 1) * -1;
            numToShow = positiveNum;
            Console.WriteLine(" " + positiveNum); //for alignment
            Console.WriteLine(negativeNum);
        }
    }
}