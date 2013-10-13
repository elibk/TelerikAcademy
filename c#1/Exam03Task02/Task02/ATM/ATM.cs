using System;
using System.Globalization;
using System.Threading;

public class ATM
{
   public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture =
            CultureInfo.GetCultureInfo("en-US");
        string expectedPin = Console.ReadLine();
        int numberOfIncorrectedEntries = int.Parse(Console.ReadLine());

        double availableMoney = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        int incorrectInputs = 0;
        bool isOver = false;

        do
        {
            string command = Console.ReadLine();
            string pin;
            switch (command)
            {
                case "Change pin":
                    pin = Console.ReadLine();
                    if (pin == expectedPin)
                    {
                        expectedPin = Console.ReadLine();
                        Console.WriteLine("Your pin code has been changed.");
                        incorrectInputs = 0;
                    }
                    else
                    {
                        incorrectInputs++;
                        if (incorrectInputs > numberOfIncorrectedEntries)
                        {
                            Console.WriteLine("The limit of incorrect pin codes has been reached. Please contact your bank.");
                            command = "End";
                        }
                        else
                        {
                            Console.WriteLine("Incorrect pin.");
                        }
                    }

                    break;

                case "Collect":
                    double wantedMoney = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    pin = Console.ReadLine();
                    if (pin == expectedPin)
                    {
                        if (wantedMoney <= availableMoney)
                        {
                            Console.WriteLine("Please take your {0:C2}.", wantedMoney);
                            command = "End";
                        }
                        else
                        {
                            Console.WriteLine("Not enough money available.");
                        }
                    }
                    else
                    {
                        incorrectInputs++;
                        if (incorrectInputs > numberOfIncorrectedEntries)
                        {
                            Console.WriteLine("The limit of incorrect pin codes has been reached. Please contact your bank.");
                            command = "End";
                        }
                        else
                        {
                            Console.WriteLine("Incorrect pin.");
                        }
                    }

                    break;

                case "End":

                    break;
                default:
                    throw new ArgumentException("Invalid command.");
            }

            if (command == "End")
            {
                Console.WriteLine("Goodbye.");
                isOver = true;
            }
        }
        while (!isOver);
    }
}

