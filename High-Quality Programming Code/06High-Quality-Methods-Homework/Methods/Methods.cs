////

namespace Methods
{
    using System;

    public class Methods
    {
        public static double GetTriangleArea(double firstBase, double secondBase, double thirdBase)
        {
            if (firstBase <= 0 || secondBase <= 0 || thirdBase <= 0)
            {
                throw new ArgumentException("Bases of the triangle should be positive value.");
            }

            double surface = GetTriangleSurface(firstBase, secondBase, thirdBase);
            double perimeter = surface / 2;
            double area = Math.Sqrt(perimeter * (perimeter - firstBase) * (perimeter - secondBase) * (perimeter - thirdBase));

            return area;
        }

        public static double GetTriangleSurface(double firstBase, double secondBase, double thirdBase)
        {
            if (firstBase <= 0)
            {
                throw new ArgumentException("The value for 'firstBase' should be positive number.");
            }

            if (secondBase <= 0)
            {
                throw new ArgumentException("The value for 'secondBase' should be positive number.");
            }

            if (thirdBase <= 0)
            {
                throw new ArgumentException("The value for 'thirdBase' should be positive number.");
            }

            double surface = firstBase + secondBase + thirdBase;

            return surface;
        }

        public static string ConvertDigitToEnglishWord(int digit)
        {
            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("Invalid value for digit. Digit must be in range for 0 to 9");
            }
        }

        public static int GetMax(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentException("The value for 'numbers' cannot be null.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("The collection 'numbers' should not be empty");
            }

            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Prints formated number on the Console
        /// </summary>
        /// <param name="number">object of type number</param>
        /// <param name="format">'f' - with two charectars after the decimal point or '%' - like percent or 'r' - aligned right </param>
        public static void PrintAsFormatedNumber(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid value for 'format'");
            }
        }

        public static double CalculateDistance(
            double firstPointCordinateX, double firstPointCordinateY, double secondPointCordinateX, double secondPointCordinateY, out bool isHorizontalLine, out bool isVerticalLine)
        {
            isHorizontalLine = IsHorizontalLine(firstPointCordinateY, secondPointCordinateY);
            isVerticalLine = IsVerticalLine(firstPointCordinateX, secondPointCordinateX);

            double deltaX = (secondPointCordinateX - firstPointCordinateX) * (secondPointCordinateX - firstPointCordinateX);
            double deltaY = (secondPointCordinateY - firstPointCordinateY) * (secondPointCordinateY - firstPointCordinateY);
            double distance = Math.Sqrt(deltaX + deltaY);

            return distance;
        }

        private static bool IsVerticalLine(double x1, double x2)
        {
            return x1 == x2;
        }

        private static bool IsHorizontalLine(double y1, double y2)
        {
            return y1 == y2;
        }

        private static void Main()
        {
            Console.WriteLine(GetTriangleArea(3, 4, 5));
            
            Console.WriteLine(ConvertDigitToEnglishWord(5));
            
            Console.WriteLine(GetMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsFormatedNumber(1.3, "f");
            PrintAsFormatedNumber(0.75, "%");
            PrintAsFormatedNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student testStudent = new Student() { FirstName = "Peter", LastName = "Ivanov", BirthDate = new DateTime(1993, 03, 17) };
            testStudent.OtherInfo = "From Sofia, born at 17.03.1992";

            Student otherTestSudent = new Student() { FirstName = "Stella", LastName = "Markova", BirthDate = new DateTime(1993, 11, 03) };
            otherTestSudent.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                "{0} older than {1} -> {2}", testStudent.FirstName, otherTestSudent.FirstName, testStudent.IsOlderThan(otherTestSudent));
        }
    }
}
