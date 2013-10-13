using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace P2MathExpression
{
    class MathExpression
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            decimal N = decimal.Parse(Console.ReadLine());
            decimal M = decimal.Parse(Console.ReadLine());
            decimal P = decimal.Parse(Console.ReadLine());
            decimal firstPart = N * N + (1 / (M * P)) + 1337;
            decimal secondPart = N - 128.523123123m * P;
            decimal thirdPart = (decimal)Math.Sin(((int)M) % 180);
            decimal result =firstPart/secondPart+thirdPart;

            Console.WriteLine("{0:F6}",result);
            
        }
    }
}