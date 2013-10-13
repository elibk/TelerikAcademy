//// methods for natural log are borrowed from here http://www.codeproject.com/Tips/311714/Natural-Logarithms-and-Exponent

namespace H03MathFunctions
{
    using System;
    using System.Linq;

    public static class NaturalLogarithm
    {
        public static double LnDouble(double power)
        {
            double N, P, L, R, A, E;
            E = 2.71828182845905;
            P = power;
            N = 0.0;

            // This speeds up the convergence by calculating the integral
            while (P >= E)
            {
                P /= E;
                N++;
            }
            N += (P / E);
            P = power;

            do
            {
                A = N;
                L = (P / (ExpDouble(N - 1.0)));
                R = ((N - 1.0) * E);
                N = ((L + R) / E);
            }
            while (N != A);

            return N;
        }

        public static double ExpDouble(double exponent)
        {
            double X, P, Frac, I, L;
            X = exponent;
            Frac = X;
            P = (1.0 + X);
            I = 1.0;

            do
            {
                I++;
                Frac *= (X / I);
                L = P;
                P += Frac;
            }
            while (L != P);

            return P;
        }

        public static float LnFloat(float power)
        {
            float N, P, L, R, A, E;
            E = 2.71828182845905f;
            P = power;
            N = 0.0f;

            // This speeds up the convergence by calculating the integral
            while (P >= E)
            {
                P /= E;
                N++;
            }
            N += (P / E);
            P = power;

            do
            {
                A = N;
                L = (P / (ExpFloat(N - 1.0f)));
                R = ((N - 1.0f) * E);
                N = ((L + R) / E);
            }
            while (N != A);

            return N;
        }

        public static float ExpFloat(float exponent)
        {
            float X, P, Frac, I, L;
            X = exponent;
            Frac = X;
            P = (1.0f + X);
            I = 1.0f;

            do
            {
                I++;
                Frac *= (X / I);
                L = P;
                P += Frac;
            }
            while (L != P);

            return P;
        }

        public static decimal LnDecimal(decimal power)
        {
            decimal N, P, L, R, A, E;
            E = 2.71828182845905m;
            P = power;
            N = 0.0m;

            // This speeds up the convergence by calculating the integral
            while (P >= E)
            {
                P /= E;
                N++;
            }
            N += (P / E);
            P = power;

            do
            {
                A = N;
                L = (P / (ExpDecimal(N - 1.0m)));
                R = ((N - 1.0m) * E);
                N = ((L + R) / E);
            }
            while (N != A);

            return N;
        }

        public static decimal ExpDecimal(decimal exponent)
        {
            decimal X, P, Frac, I, L;
            X = exponent;
            Frac = X;
            P = (1.0m + X);
            I = 1.0m;

            do
            {
                I++;
                Frac *= (X / I);
                L = P;
                P += Frac;
            }
            while (L != P);

            return P;
        }
    }
}
