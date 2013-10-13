
//Comapare number 
using System;

    class CompareFPNum
    {
        static void Main()
        {
           
            Console.WriteLine("Whant to know if it's true that num X is equal to numY with precision of 0.000001?");
            Console.WriteLine("Enter first num:");
            decimal oneNum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter second num:");
            decimal otherNum = Convert.ToDecimal(Console.ReadLine());
            decimal chek = (oneNum - otherNum);
            decimal chek2 = (otherNum - oneNum);
            bool compare = (chek < 0.000001m);
            bool compare2 = (chek2 < 0.000001m);
            bool finalcompare = (compare == compare2 == true); 
            Console.WriteLine("It is {0}.", finalcompare);  
            
        }
    }

/*
//Comapare number 
using System;

    class CompareFPNum
    {
        static void Main()
        {
            Console.WriteLine("Whant to know if it's true that numX is equal to numY with precision of 0.000001?");
            Console.WriteLine("Enter first num:");
            decimal oneNum = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter second num:");
            decimal otherNum = decimal.Parse(Console.ReadLine());
            if (oneNum > otherNum)
            {
                bool compare = ((oneNum - otherNum) < 0.000001m);
                Console.WriteLine("It is {0}.", compare);
            }
            else
            {
                bool compare = ((otherNum - oneNum) < 0.000001m);
                Console.WriteLine("It is {0}.", compare);
            }
            
             
        }
    }
*/