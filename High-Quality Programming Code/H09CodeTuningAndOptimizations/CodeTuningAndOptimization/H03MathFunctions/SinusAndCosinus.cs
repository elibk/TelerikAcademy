//// methods for calculatin Sin and Cos are borrowed from here
//// http://stackoverflow.com/questions/3249710/accuracy-of-math-sin-and-math-cos-in-c-sharp

namespace H03MathFunctions
{
    using System;
    using System.Linq;

    public static class SinusAndCosinus
    {
        private const decimal PiDecimal = 3.14m;
        private const decimal PiHalfDecimal = PiDecimal / 2m;
        private const decimal PiQuarterDecimal = PiDecimal / 4m;

        private const double PiDouble = 3.14;
        private const double PiHalfDouble = PiDouble / 2d;
        private const double PiQuarterDouble = PiDouble / 4d;

        private const float PiFloat = 3.14f;
        private const float PiHalfFloat = PiFloat / 2;
        private const float PiQuarterFloat = PiFloat / 4;

        public static decimal SinDecimal(decimal x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x < 0)
            {
                return -SinDecimal(-x);
            }
            if (x > PiDecimal)
            {
                return -SinDecimal(x - PiDecimal);
            }
            if (x > PiQuarterDecimal)
            {
                return CosDecimal(PiHalfDecimal - x);
            }

            decimal x2 = x * x;

            return x * (x2 / 6 * (x2 / 20 * (x2 / 42 * (x2 / 72 * (x2 / 110 * (x2 / 156 - 1) + 1) - 1) + 1) - 1) + 1);
        }

        public static decimal CosDecimal(decimal x)
        {
            if (x == 0)
            {
                return 1;
            }
            if (x < 0)
            {
                return CosDecimal(-x);
            }
            if (x > PiDecimal)
            {
                return -CosDecimal(x - PiDecimal);
            }
            if (x > PiQuarterDecimal)
            {
                return SinDecimal(PiHalfDecimal - x);
            }

            decimal x2 = x * x;

            return x2 / 2 * (x2 / 12 * (x2 / 30 * (x2 / 56 * (x2 / 90 * (x2 / 132 - 1) + 1) - 1) + 1) - 1) + 1;
        }

        public static double SinDouble(double x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x < 0)
            {
                return -SinDouble(-x);
            }
            if (x > PiDouble)
            {
                return -SinDouble(x - PiDouble);
            }
            if (x > PiQuarterDouble)
            {
                return CosDouble(PiHalfDouble - x);
            }

            double x2 = x * x;

            return x * (x2 / 6 * (x2 / 20 * (x2 / 42 * (x2 / 72 * (x2 / 110 * (x2 / 156 - 1) + 1) - 1) + 1) - 1) + 1);
        }

        public static double CosDouble(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            if (x < 0)
            {
                return CosDouble(-x);
            }
            if (x > PiDouble)
            {
                return -CosDouble(x - PiDouble);
            }
            if (x > PiQuarterDouble)
            {
                return SinDouble(PiHalfDouble - x);
            }

            double x2 = x * x;

            return x2 / 2 * (x2 / 12 * (x2 / 30 * (x2 / 56 * (x2 / 90 * (x2 / 132 - 1) + 1) - 1) + 1) - 1) + 1;
        }

        public static float SinFloat(float x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x < 0)
            {
                return -SinFloat(-x);
            }
            if (x > PiFloat)
            {
                return -SinFloat(x - PiFloat);
            }
            if (x > PiFloat)
            {
                return CosFloat(PiFloat - x);
            }

            float x2 = x * x;

            return x * (x2 / 6 * (x2 / 20 * (x2 / 42 * (x2 / 72 * (x2 / 110 * (x2 / 156 - 1) + 1) - 1) + 1) - 1) + 1);
        }

        public static float CosFloat(float x)
        {
            if (x == 0)
            {
                return 1;
            }
            if (x < 0)
            {
                return CosFloat(-x);
            }
            if (x > PiFloat)
            {
                return -CosFloat(x - PiFloat);
            }
            if (x > PiQuarterFloat)
            {
                return SinFloat(PiHalfFloat - x);
            }

            float x2 = x * x;

            return x2 / 2 * (x2 / 12 * (x2 / 30 * (x2 / 56 * (x2 / 90 * (x2 / 132 - 1) + 1) - 1) + 1) - 1) + 1;
        }
    }
}
