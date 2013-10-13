using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Midget
{
    class Midget
    {
        static void Main(string[] args)
        {
            List<int> valley = ConvertToSequenceOfIntegers(Console.ReadLine());
            short N = short.Parse(Console.ReadLine());
            List<int>[] patterns = new List<int>[N];

            for (int i = 0; i < N; i++)
            {
                patterns[i] = ConvertToSequenceOfIntegers(Console.ReadLine());
            }
            //////Read input

            //List<int> valley = new List<int> {1};
            //short N = 1;
            //List<int>[] patterns = new List<int>[N];

            //for (int i = 0; i < N; i++)
            //{
            //    patterns[i] = ConvertToSequenceOfIntegers(Console.ReadLine());
            //}
            //////Read input

            List<int> valleyCurrent = new List<int>();
            valleyCurrent.AddRange(valley);
            long maxSum = long.MinValue;
            long currentSum = new long ();
            int positionInTheVallay = 0;
            bool escape = false;

            for (int i = 0; i < N; i++)
            {
                currentSum = valleyCurrent[positionInTheVallay];
                valleyCurrent[positionInTheVallay] = 9999;
                ////посетена

                while (escape == false)
                {
                    for (int step = 0; step < patterns[i].Count; step++)
                    {
                        positionInTheVallay = positionInTheVallay + patterns[i][step];

                        if (positionInTheVallay < 0 || positionInTheVallay > valley.Count - 1 )
                        {
                            escape = true;
                            break;
                        }
                        else if (valleyCurrent[positionInTheVallay] == 9999)
                        {
                            escape = true;
                            break;
                        }
                        currentSum += valleyCurrent[positionInTheVallay];
                        valleyCurrent[positionInTheVallay] = 9999;
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }

                valleyCurrent.Clear();
                valleyCurrent.AddRange(valley);
                positionInTheVallay = 0;
                currentSum = 0;
                escape = false;
               
            }

            Console.WriteLine(maxSum);

            //foreach (var item in valley)
            //{
            //    Console.Write(" " + item);
            //}
            //Console.WriteLine();
            //foreach (var item in valleyCurrent)
            //{
            //    Console.Write(" " + item);
            //}
            //Console.WriteLine();

        }

        private static List<int> ConvertToSequenceOfIntegers(string sequence)
        {
            List<int> numbers = new List<int>();
            int count = new int();
            sequence = sequence.Trim();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == ',')
                {
                    numbers.Add(int.Parse(sequence.Substring(i - count, count)));
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            numbers.Add(int.Parse(sequence.Substring((sequence.Length) - count, count)));
            count = 0;

            return numbers;
        }
    }
}
