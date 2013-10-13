using System;

namespace ExchangeOfValues
{
    class ExchangeValues
    {
        static void Main()
        {
            int firstValue = 24;
            int secondValue = 42;
            int middleFirst = 0;
            int middleSecond = 0;

            Console.WriteLine("Before exchange: {0},{1}:",firstValue,secondValue);
            middleFirst = firstValue;
            middleSecond = secondValue;
            firstValue = middleSecond;
            secondValue = middleFirst;
            Console.WriteLine("After exchange: {0},{1}",firstValue,secondValue);
        }
    }
}
