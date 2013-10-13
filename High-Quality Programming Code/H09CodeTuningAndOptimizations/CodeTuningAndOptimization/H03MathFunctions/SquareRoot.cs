//// methods for SqrtRoot and Pow are borrowed from here http://www.codeproject.com/Tips/311714/Natural-Logarithms-and-Exponent
namespace H03MathFunctions
{
    using System;
    using System.Linq;

    public static class SquareRoot
    {
        public static double Pow(double Base, double Power)
        {
            return NaturalLogarithm.ExpDouble(Power * NaturalLogarithm.LnDouble(Base));
        }

        public static double SqrtRoot(double number)
        {
            /* (C) John Gabriel */
            double Rt = 2.0;
            double A, N, S, T, L, R;
            A = number;
            N = Rt;
            S = 1.0;

            do
            {
                T = S;
                L = (A / Math.Pow(S, (N - 1.0)));
                R = (N - 1.0) * S;
                S = (L + R) / N;
            }
            while (L != S);

            return S;
        }
    }
}
