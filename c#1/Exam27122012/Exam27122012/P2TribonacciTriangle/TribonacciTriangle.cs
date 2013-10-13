using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2TribonacciTriangle
{
    class TribonacciTriangle
    {
        static void Main(string[] args)
        {

            long[] numbersFromOutput = new long[4];



            for (int i = 0; i < numbersFromOutput.Length - 1; i++)
            {
                numbersFromOutput[i] = int.Parse(Console.ReadLine());
            }

            int L = int.Parse(Console.ReadLine());
            int quadronacciLen = L * L;
            long[] quadronacciNums = new long[quadronacciLen];

            for (int i = 0; i < numbersFromOutput.Length - 1; i++)
            {
                quadronacciNums[i] = numbersFromOutput[i];  //put first four members
            }

            for (int i = 4, positionInQuadronacci = 3; i <= quadronacciLen; i++, positionInQuadronacci++)
            {
                numbersFromOutput[3] = numbersFromOutput[0] + numbersFromOutput[1] + numbersFromOutput[2];
                numbersFromOutput[0] = numbersFromOutput[1];
                numbersFromOutput[1] = numbersFromOutput[2];
                numbersFromOutput[2] = numbersFromOutput[3];
                quadronacciNums[positionInQuadronacci] = numbersFromOutput[3];


            }
            int currentPositionInQuadronacci = 0;
            for (int row = 0; row <= L - 1; row++)
            {
                for (int i = currentPositionInQuadronacci, col = 0; col <= row; i++, col++)
                {
                    Console.Write(quadronacciNums[i] + " ");
                    currentPositionInQuadronacci++;

                }
                Console.WriteLine();
            }
        }
    }
}
