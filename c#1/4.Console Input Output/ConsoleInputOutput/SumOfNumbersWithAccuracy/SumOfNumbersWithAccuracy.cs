using System;

class SumOfNumbersWithAccuracy
{
    static void Main()
    {
        Console.Write("Sum of how many numbers in row 1 + 1/2 - 1/3 + 1/4 - 1/5 + ... you want to see?");
        int membersToSum = int.Parse(Console.ReadLine()); 
        int member = 0;
        double firstnumber = 1;
        int divider = 2;
        double numOfSum;
        double sum = 1 ;
        Console.Write("num {0:0.000} ;", firstnumber);
        while (member < membersToSum -1)
          
        {
            member++;
            numOfSum = firstnumber / divider;
            
            if (divider%2 == 0)
            {
                numOfSum = Math.Abs(numOfSum);
                
            }
            else
            {
                numOfSum = numOfSum * -1;
            }
            divider++;
            sum = sum + numOfSum;
           
            Console.Write("num {0:0.000} ;",numOfSum);
        }
        Console.WriteLine("\nThe sum first {1} numbers of this line is {0:0.000}", sum, membersToSum);
    }
}

