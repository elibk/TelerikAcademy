using System;

class NumDivededOnFive
{
    static void Main(string[] args)
    {
        Console.Write(
            "Enter interwal between number to see how many numbers cen be divided with 5 whithout reminder:\nEnter num for start of the interval:");
        int firstNum = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number for end of the interval:");
        int secondNum = Convert.ToInt32(Console.ReadLine());
        int p = 0;
        int holdValueOfDivision = 0;
        if (firstNum < secondNum)
        {
            do
            {
                holdValueOfDivision = firstNum % 5;
                if (holdValueOfDivision == 0)
                {
                    p++;
                }
                firstNum++;
            } while (firstNum <= secondNum);

            if (p == 1)
            {
                Console.WriteLine("There is one number which you can divide on 5 whitout reminder",firstNum,secondNum);
            }
            if (p==0)
            {
                Console.WriteLine("There are no numbers which you can divide on 5 whitout reminder");
            }
            if (p > 1)
            {
                Console.WriteLine("There are {2} numbers which you can divide on 5 whitout reminder", firstNum, secondNum, p);
            }
        }
        else
        {
            Console.WriteLine("Incorect input!");
        }
    }
}
