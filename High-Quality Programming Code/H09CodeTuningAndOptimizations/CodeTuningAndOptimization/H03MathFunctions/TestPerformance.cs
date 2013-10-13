////
namespace H03MathFunctions
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

   public class TestPerformance
    {
        private const int CountOfOperations = 1000;
        private static readonly Stopwatch RecordTime = new Stopwatch();

       public static void Main(string[] args)
        {
            object[] param = new object[1];

            ////// there is some misleading in the result of some of first invocing of the operation that changes from types from doubles
            ////// to decimals. My guess it is becouse of the change of CPU behaviour.

            param[0] = 1;
            DisplayReportForPerformance("SinusWithFloat", param);
            DisplayReportForPerformance("SinusWithFloat", param);
            DisplayReportForPerformance("SinusWithFloat", param);

            param[0] = 1.2;
            DisplayReportForPerformance("SinusWithDouble", param);
            DisplayReportForPerformance("SinusWithDouble", param);
            DisplayReportForPerformance("SinusWithDouble", param);

            param[0] = 1.2m;
            DisplayReportForPerformance("SinusWithDecimal", param);
            DisplayReportForPerformance("SinusWithDecimal", param);
            DisplayReportForPerformance("SinusWithDecimal", param);

            Console.WriteLine(new string('#', Console.WindowWidth));
            /// doesn't seems to work for floating point numbers diven as param
            param[0] = 5;
            DisplayReportForPerformance("NaturalLogarithmFloat", param);
            DisplayReportForPerformance("NaturalLogarithmFloat", param);
            DisplayReportForPerformance("NaturalLogarithmFloat", param);

            param[0] = 5.0;
            DisplayReportForPerformance("NaturalLogarithmDouble", param);
            DisplayReportForPerformance("NaturalLogarithmDouble", param);
            DisplayReportForPerformance("NaturalLogarithmDouble", param);

            param[0] = 5.0m;
            DisplayReportForPerformance("NaturalLogarithmDecimal", param);
            DisplayReportForPerformance("NaturalLogarithmDecimal", param);
            DisplayReportForPerformance("NaturalLogarithmDecimal", param);

            Console.WriteLine(new string('#', Console.WindowWidth));
            //// unfortunatly I couldn't come up with good function for Pow so I could replace double with decimal
            //// so only tests for double for method I found this from class Math

            param[0] = 5.0;
            DisplayReportForPerformance("SqrtDouble", param);
            DisplayReportForPerformance("SqrtDouble", param);
            DisplayReportForPerformance("SqrtDouble", param);

            DisplayReportForPerformance("SqrtDoubleFromMath", param);
            DisplayReportForPerformance("SqrtDoubleFromMath", param);
            DisplayReportForPerformance("SqrtDoubleFromMath", param);
        }

        public static void SqrtDouble(double number)
        {
            double sqrt;

            RecordTime.Start();
            sqrt = SquareRoot.SqrtRoot(number);
            RecordTime.Stop();
        }

        public static void SqrtDoubleFromMath(double number)
        {
            double sqrt;

            RecordTime.Start();
            sqrt = Math.Sqrt(number);
            RecordTime.Stop();
        }

        public static void NaturalLogarithmFloat(float number)
        {
            float result;
            RecordTime.Start();
            result = NaturalLogarithm.LnFloat(number);
            RecordTime.Stop();
        }

        public static void NaturalLogarithmDouble(double number)
        {
            double result;
            RecordTime.Start();
            result = NaturalLogarithm.LnDouble(number);
            RecordTime.Stop();
        }

        public static void NaturalLogarithmDecimal(decimal number)
        {
            decimal result;
            RecordTime.Start();
            result = NaturalLogarithm.LnDecimal(number);
            RecordTime.Stop();
        }

        public static void SinusWithFloat(float number)
        {
            float result;

            RecordTime.Start();
            result = SinusAndCosinus.SinFloat(number);
            RecordTime.Stop();
        }

        public static void SinusWithDouble(double number)
        {
            double result;
            RecordTime.Start();
            result = SinusAndCosinus.SinDouble(number);
            RecordTime.Stop();
        }

        public static void SinusWithDecimal(decimal number)
        {
            decimal result;
            RecordTime.Start();
            result = SinusAndCosinus.SinDecimal(number);
            RecordTime.Stop();
        }

        private static void DisplayReportForPerformance(string methodName, object[] parameters)
        {
            RecordTime.Reset();
            Type classType = typeof(TestPerformance);
            MethodInfo method = classType.GetMethod(methodName);
            if (method != null)
            {
                for (int i = 0; i < CountOfOperations; i++)
                {
                    method.Invoke(null, parameters);
                }
            }

            Console.WriteLine(methodName);
            Console.WriteLine("Performed {0} operations. Time elapsed in milliseconds {1}.", CountOfOperations, RecordTime.Elapsed.TotalMilliseconds);
            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}
