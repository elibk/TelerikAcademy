// Write a program that applies bonus scores to given scores in the range [1..9]. 
//The program reads a digit as an input. If the digit is between 1 and 3, 
//the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100;
//if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, 
//the program must report an error.
using System;

class BonusScores
{
    static void Main()
    {
        Console.Write("Enter your score [1....9]:");
        int score = int.Parse(Console.ReadLine());
        switch (score)
        {
            case 1:
            case 2:
            case 3:
                Console.WriteLine("B O N U S! Your score is now: {0}.", score*10);
                break;
            case 4:
            case 5:
            case 6:
                Console.WriteLine("B O N U S! Your score is now: {0}.",score*100);
                break;
            case 7:
            case 8:
            case 9:
                Console.WriteLine("B O N U S! Your score is now: {0}.",score * 1000);
                break;
            default:
                Console.WriteLine("Error!!!!!!!!");
                break;
        }
    }
}
