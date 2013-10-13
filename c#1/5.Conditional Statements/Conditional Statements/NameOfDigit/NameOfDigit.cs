using System;

class NameOfDigit
{
    enum Digits
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9
        
    }
    static void Main()
    {
        Console.WriteLine("Enter number [0...9] to see the english and the italian word for it.");
        int num = int.Parse(Console.ReadLine());
        Digits digit = (Digits)num;
        switch (digit)
        {
            case Digits.Zero:
                Console.WriteLine("Zero or \"Zero\"");
                break;
            case Digits.One:
                Console.WriteLine("One or \"Uno\"");
                break;
            case Digits.Two:
                Console.WriteLine("Two or \"Due\"");
                break;
            case Digits.Three:
                Console.WriteLine("Three or \"Tre\"");
                break;
            case Digits.Four:
                Console.WriteLine("Four or \"Quattro\"");
                break;
            case Digits.Five:
                Console.WriteLine("Five or \"Cinque\"");
                break;
            case Digits.Six:
                Console.WriteLine("Six or \"Sei\"");
                break;
            case Digits.Seven:
                Console.WriteLine("Seven or \"Sette\"");
                break;
            case Digits.Eight:
                Console.WriteLine("Eight or \"Otto\"");
                break;
            case Digits.Nine:
                Console.WriteLine("Nine or \"Nove\"");
                break;
            default:
                Console.WriteLine("Incorrect!");
                break;
        }
    }
}

