using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2QuadronacciRectangle
{
    class QuadronacciRectangle
    {
        static void Main(string[] args)
        {

            BigInteger[] numbersFromOutput = new BigInteger[5];
            


            for (int i = 0; i < numbersFromOutput.Length -1; i++)
            {
                numbersFromOutput[i] = int.Parse(Console.ReadLine());               
            }

            int R = int.Parse(Console.ReadLine());
            int C = int.Parse(Console.ReadLine());
            int quadronacciLen = R * C;
            BigInteger[] quadronacciNums = new BigInteger[quadronacciLen];

            for (int i = 0; i < numbersFromOutput.Length - 1; i++)
            {
                quadronacciNums[i] = numbersFromOutput[i];  //put first four members
            }

            for (int i = 5, positionInQuadronacci = 4; i <= quadronacciLen; i++, positionInQuadronacci++)
            {
                numbersFromOutput[4] = numbersFromOutput[0] + numbersFromOutput[1] + numbersFromOutput[2] + numbersFromOutput [3];
                numbersFromOutput[0] = numbersFromOutput[1];
                numbersFromOutput[1] = numbersFromOutput[2];
                numbersFromOutput[2] = numbersFromOutput[3];
                numbersFromOutput[3] = numbersFromOutput[4];
                quadronacciNums[positionInQuadronacci] = numbersFromOutput[4];

                
            }
            int currentPositionInQuadronacci = 0;
            for (int row = 0; row <= R-1; row++)
            {
                for (int i = currentPositionInQuadronacci, col = 0; col <= C-1; i++, col++)
                {
                    Console.Write(quadronacciNums[i]+" ");
                    currentPositionInQuadronacci++;

                }
                Console.WriteLine();
            }
            
        }
    }
}
