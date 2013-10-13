////
namespace H13SolveTreeMathTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class SolveTreeMathTasks
    {
      private static void Main(string[] args)
        {
            bool check;
            
            do
            {
                Console.Clear();
                Console.WriteLine("You can solve one of the following tasks.\n1.Reverse the digits of a number\n2.Calculate the average of a sequence of integers\n3.Solves a linear equation a * x + b = 0");
                Console.Write("Enter the number of the task you want to solve:");
                check = true;
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Please enter positive integer number:");
                        string number = Console.ReadLine();
                        number = ReverseDigits(number);
                        Console.WriteLine("Reversed was done. The number now is {0}.", number);
                        break;
                    case "2":
                        Console.WriteLine("Enter sequace of integer numbers, divided by ; (1;2;3;...n):");
                        string sequence = Console.ReadLine();
                        double average = GetAverage(sequence);
                        Console.WriteLine("The averige is:{0}", average);
                        break;
                    case "3":
                        Console.Write("a = ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("b = ");
                        double b = double.Parse(Console.ReadLine());
                        double x = SolveLinearEquation(a, b);

                        Console.WriteLine("In {0}*x + {1} = 0\nx = {2}", a, b, x);

                        break;

                    default:
                        check = false;
                        break;
                }
            } 
            while (check == false);     
        }

        private static double SolveLinearEquation(double a, double b)
        {
            if (a == 0)
            {
                throw new DivideByZeroException("a should not be equal to 0.");
            }
            else
            {
                double x = (-b) / a;
                return x;
            }
        }

        private static double GetAverage(string sequence)
        {
            if (sequence == string.Empty)
            {
                Exception emptySequence = new Exception("The sequence should not be empty.");
                throw emptySequence;
            }
            else
            {
                List<int> numbers = new List<int>();
                int count = new int();
                double average = new int();

                if (sequence.LastIndexOf(';') == sequence.Length - 1)
                {
                    sequence = sequence.Substring(0, sequence.Length - 1);
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == ';')
                    {
                        numbers.Add(int.Parse(sequence.Substring(i - count, count)));
                        count = 0;
                    }
                    else
                    {
                        count++;
                    }
                }

                numbers.Add(int.Parse(sequence.Substring((sequence.Length) -count, count)));
                count = 0;

                average = numbers.Sum() / (double)numbers.Count;
                return average;
            }        
        }

        private static string ReverseDigits(string number)
        {  
            if (number[0] == '-')
            {
                Exception negativeNumberExeption = new Exception("The number should be non-negative.");
                throw negativeNumberExeption;
            }
            else
            {
                string reversed = string.Empty;
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    reversed += number[i];
                }

                for (int i = 0; i < reversed.Length; i++)
                {
                    if (reversed[i] != '0')
                    {
                        reversed = reversed.Substring(i);
                        break;
                    }
                }

                return reversed;
            }
        }
    }
}
