////

namespace H02BasicMathTest
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
            // there is some misleading in the result of some of first invocing of the operation that changes from adding doubles
            // to adding decimals. My guess it is becouse of the change of CPU behaviour.
            object[] param = new object[2];
           
            param[0] = 5;
            param[1] = 5;
            DisplayReportForPerformance("AddIntegers", param);
            DisplayReportForPerformance("AddIntegers", param);
            DisplayReportForPerformance("AddIntegers", param);
            param[0] = 5L;
            param[1] = 5L;
            DisplayReportForPerformance("AddLongs", param);
            DisplayReportForPerformance("AddLongs", param);
            DisplayReportForPerformance("AddLongs", param);
            param[0] = 5f;
            param[1] = 5f;
            DisplayReportForPerformance("AddFloats", param);
            DisplayReportForPerformance("AddFloats", param);
            DisplayReportForPerformance("AddFloats", param);
            param[0] = 5.0;
            param[1] = 5.0;
            DisplayReportForPerformance("AddDoubles", param);
            DisplayReportForPerformance("AddDoubles", param);
            DisplayReportForPerformance("AddDoubles", param);
            param[0] = 5.0m;
            param[1] = 5.0m;
            DisplayReportForPerformance("AddDecimals", param);
            DisplayReportForPerformance("AddDecimals", param);
            DisplayReportForPerformance("AddDecimals", param);
            Console.WriteLine(new string('#', Console.WindowWidth));

            param[0] = 5;
            param[1] = 5;
            DisplayReportForPerformance("SubtractIntegers", param);
            DisplayReportForPerformance("SubtractIntegers", param);
            DisplayReportForPerformance("SubtractIntegers", param);
            param[0] = 5L;
            param[1] = 5L;
            DisplayReportForPerformance("SubtractLongs", param);
            DisplayReportForPerformance("SubtractLongs", param);
            DisplayReportForPerformance("SubtractLongs", param);
            param[0] = 5f;
            param[1] = 5f;
            DisplayReportForPerformance("SubtractFloats", param);
            DisplayReportForPerformance("SubtractFloats", param);
            DisplayReportForPerformance("SubtractFloats", param);
            param[0] = 5.0;
            param[1] = 5.0;
            DisplayReportForPerformance("SubtractDoubles", param);
            DisplayReportForPerformance("SubtractDoubles", param);
            DisplayReportForPerformance("SubtractDoubles", param);
            param[0] = 5.0m;
            param[1] = 5.0m;
            DisplayReportForPerformance("SubtractDecimals", param);
            DisplayReportForPerformance("SubtractDecimals", param);
            DisplayReportForPerformance("SubtractDecimals", param);

            Console.WriteLine(new string('#', Console.WindowWidth));

            param = new object[1];

            param[0] = 5;
           
            DisplayReportForPerformance("IncreaseInteger", param);
            DisplayReportForPerformance("IncreaseInteger", param);
            DisplayReportForPerformance("IncreaseInteger", param);
            param[0] = 5L;
           
            DisplayReportForPerformance("IncreaseLong", param);
            DisplayReportForPerformance("IncreaseLong", param);
            DisplayReportForPerformance("IncreaseLong", param);
            param[0] = 5f;
           
            DisplayReportForPerformance("IncreaseFloat", param);
            DisplayReportForPerformance("IncreaseFloat", param);
            DisplayReportForPerformance("IncreaseFloat", param);
            param[0] = 5.0;
           
            DisplayReportForPerformance("IncreaseDouble", param);
            DisplayReportForPerformance("IncreaseDouble", param);
            DisplayReportForPerformance("IncreaseDouble", param);
            param[0] = 5.0m;

            DisplayReportForPerformance("IncreaseDecimal", param);
            DisplayReportForPerformance("IncreaseDecimal", param);
            DisplayReportForPerformance("IncreaseDecimal", param);
            DisplayReportForPerformance("IncreaseDecimal", param);

            Console.WriteLine(new string('#', Console.WindowWidth));
            param = new object[2];
            param[0] = 5;
            param[1] = 5;

            DisplayReportForPerformance("MultiplyIntegers", param);
            DisplayReportForPerformance("MultiplyIntegers", param);
            DisplayReportForPerformance("MultiplyIntegers", param);
            param[0] = 5L;
            param[1] = 5L;
            DisplayReportForPerformance("MultiplyLongs", param);
            DisplayReportForPerformance("MultiplyLongs", param);
            DisplayReportForPerformance("MultiplyLongs", param);
            param[0] = 5f;
            param[1] = 5f;
            DisplayReportForPerformance("MultiplyFloats", param);
            DisplayReportForPerformance("MultiplyFloats", param);
            DisplayReportForPerformance("MultiplyFloats", param);
            param[0] = 5.0;
            param[1] = 5.0;
            DisplayReportForPerformance("MultiplyDoubles", param);
            DisplayReportForPerformance("MultiplyDoubles", param);
            DisplayReportForPerformance("MultiplyDoubles", param);
            param[0] = 5.0m;
            param[1] = 5.0m;
            DisplayReportForPerformance("MultiplyDecimals", param);
            DisplayReportForPerformance("MultiplyDecimals", param);
            DisplayReportForPerformance("MultiplyDecimals", param);

            Console.WriteLine(new string('#', Console.WindowWidth));

            param[0] = 5;
            param[1] = 5;
            DisplayReportForPerformance("DivideInteger", param);
            DisplayReportForPerformance("DivideInteger", param);
            DisplayReportForPerformance("DivideInteger", param);
            param[0] = 5L;
            param[1] = 5L;
            DisplayReportForPerformance("DivideLong", param);
            DisplayReportForPerformance("DivideLong", param);
            DisplayReportForPerformance("DivideLong", param);
            param[0] = 5f;
            param[1] = 5f;
            DisplayReportForPerformance("DivideFloat", param);
            DisplayReportForPerformance("DivideFloat", param);
            DisplayReportForPerformance("DivideFloat", param);
            param[0] = 5.0;
            param[1] = 5.0;
            DisplayReportForPerformance("DivideDouble", param);
            DisplayReportForPerformance("DivideDouble", param);
            DisplayReportForPerformance("DivideDouble", param);
            param[0] = 5.0m;
            param[1] = 5.0m;
            DisplayReportForPerformance("DivideDecimal", param);
            DisplayReportForPerformance("DivideDecimal", param);
            DisplayReportForPerformance("DivideDecimal", param);
        }

        #region Addition

        public static void AddIntegers(int firstNumber, int secondNumber)
        {
            RecordTime.Start();
            int sum = firstNumber + secondNumber;
            RecordTime.Stop();
        }

        public static void AddLongs(long firstNumber, long secondNumber)
        {
            RecordTime.Start();
            long sum = firstNumber + secondNumber;
            RecordTime.Stop();
        }

        public static void AddFloats(float firstNumber, float secondNumber)
        {
            RecordTime.Start();
            float sum = firstNumber + secondNumber;
            RecordTime.Stop();
        }

        public static void AddDoubles(double firstNumber, double secondNumber)
        {
            RecordTime.Start();
            double sum = firstNumber + secondNumber;
            RecordTime.Stop();
        }

        public static void AddDecimals(decimal firstNumber, decimal secondNumber)
        {
            RecordTime.Start();
            decimal sum = firstNumber + secondNumber;
            RecordTime.Stop();
        }

        #endregion

        #region Subtraction

        public static void SubtractIntegers(int firstNumber, int secondNumber)
        {
            RecordTime.Start();
            int sum = firstNumber - secondNumber;
            RecordTime.Stop();
        }

        public static void SubtractLongs(long firstNumber, long secondNumber)
        {
            RecordTime.Start();
            long sum = firstNumber - secondNumber;
            RecordTime.Stop();
        }

        public static void SubtractFloats(float firstNumber, float secondNumber)
        {
            RecordTime.Start();
            float sum = firstNumber - secondNumber;
            RecordTime.Stop();
        }

        public static void SubtractDoubles(double firstNumber, double secondNumber)
        {
            RecordTime.Start();
            double sum = firstNumber - secondNumber;
            RecordTime.Stop();
        }

        public static void SubtractDecimals(decimal firstNumber, decimal secondNumber)
        {
            RecordTime.Start();
            decimal sum = firstNumber - secondNumber;
            RecordTime.Stop();
        }

        #endregion

        #region Increment

        public static void IncreaseInteger(int number)
        {
            RecordTime.Start();
            number++;
            RecordTime.Stop();
        }

        public static void IncreaseLong(long number)
        {
            RecordTime.Start();
            number++;
            RecordTime.Stop();
        }

        public static void IncreaseFloat(float number)
        {
            RecordTime.Start();
            number++;
            RecordTime.Stop();
        }

        public static void IncreaseDouble(double number)
        {
            RecordTime.Start();
            number++;
            RecordTime.Stop();
        }

        public static void IncreaseDecimal(decimal number)
        {
            RecordTime.Start();
            number++;
            RecordTime.Stop();
        }

        #endregion

        #region Multiplication

        public static void MultiplyIntegers(int firstNumber, int secondNumber)
        {
            int product;
            RecordTime.Start();
            product = firstNumber * secondNumber;
            RecordTime.Stop();
        }

        public static void MultiplyLongs(long firstNumber, long secondNumber)
        {
            long product;
            RecordTime.Start();
            product = firstNumber * secondNumber;
            RecordTime.Stop();
        }

        public static void MultiplyFloats(float firstNumber, float secondNumber)
        {
            float product;
            RecordTime.Start();
            product = firstNumber * secondNumber;
            RecordTime.Stop();
        }

        public static void MultiplyDoubles(double firstNumber, double secondNumber)
        {
            double product;
            RecordTime.Start();
            product = firstNumber * secondNumber;
            RecordTime.Stop();
        }

        public static void MultiplyDecimals(decimal firstNumber, decimal secondNumber)
        {
            decimal product;
            RecordTime.Start();
            product = firstNumber * secondNumber;
            RecordTime.Stop();
        }

        #endregion

        #region Division

        public static void DivideInteger(int number, int divider)
        {
            int product;
            RecordTime.Start();
            product = number / divider;
            RecordTime.Stop();
        }

        public static void DivideLong(long number, long divider)
        {
            long product;
            RecordTime.Start();
            product = number / divider;
            RecordTime.Stop();
        }

        public static void DivideFloat(float number, float divider)
        {
            float product;
            RecordTime.Start();
            product = number / divider;
            RecordTime.Stop();
        }

        public static void DivideDouble(double number, double divider)
        {
            double product;
            RecordTime.Start();
            product = number / divider;
            RecordTime.Stop();
        }

        public static void DivideDecimal(decimal number, decimal divider)
        {
            decimal product;
            RecordTime.Start();
            product = number / divider;
            RecordTime.Stop();
        }

        #endregion

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
