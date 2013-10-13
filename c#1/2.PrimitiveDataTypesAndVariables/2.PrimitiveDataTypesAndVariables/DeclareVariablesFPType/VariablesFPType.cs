using System;

    class VariablesFPType
    {
        static void Main()
        {
            double moreThanSixNumAfterPoint =34.567839023;
            float notManyNumAfterPoint = 12.345f; 
            double otherMoreThanSixNumAfterPoint = 8923.1234857;
            float otherNotManyNumAfterPoint = 3456.091f;

            Console.WriteLine("Need to be more punctual - use double: {0};{1}",moreThanSixNumAfterPoint,otherMoreThanSixNumAfterPoint);
            Console.WriteLine("Don't need more than six num after point - use float (NEED suffix f!!!): {0};{1}",notManyNumAfterPoint, otherNotManyNumAfterPoint);
        }
    }
