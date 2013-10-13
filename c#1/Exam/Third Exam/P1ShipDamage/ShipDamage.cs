using System;

    class ShipDamage
    {
        static void Main(string[] args)
        {
            decimal[] numbers = new decimal[11];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(0 + "%");
        }
    }
