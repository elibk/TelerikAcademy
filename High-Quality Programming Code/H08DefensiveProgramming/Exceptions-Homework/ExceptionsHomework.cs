using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        #region data_validation
        if (startIndex < 0)
        {
            throw new ArgumentException("The value of 'startIndex' can not be negative number.");
        }

        if (count < 0)
        {
            throw new ArgumentException("The value of 'count' can not be negative number.");
        }

        if (startIndex >= arr.Length)
        {
            throw new ArgumentException(
                string.Format("Value of 'startIndex' can not be outside the bounce off 'arr'. In this case should be less than {0}.", arr.Length));
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentException(
                string.Format("The sum of 'startIndex' + 'count'(current value : {0}) can not be outside the bounce off 'arr'. In this case should be less than {1}.", startIndex + count, arr.Length + 1));
        }
        #endregion

        List<T> result = new List<T>();

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentException(
                string.Format("Value of 'count' can not be greater than the lenght of 'str'. In this case should be less than {0}.", str.Length));
        }

        StringBuilder result = new StringBuilder();

        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        //// I know there is better way to check if number is not prime, for example with return bool, 
        //// but I didn't want to change the logic in Main method
 
        if (number < 2)
        {
            throw new NotPrimeNumberException(number);
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                throw new NotPrimeNumberException(number);
            }
        }
    }

   internal static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
       //// Console.WriteLine(ExtractEnding("Hi", 100)); // this will trow ArrgumentExeption

        try
        {
            int numberForCheck = 23;
            CheckPrime(numberForCheck);
            Console.WriteLine("{0} is prime.", numberForCheck);
        }
        catch (NotPrimeNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            int numberForCheck = 33;
            CheckPrime(numberForCheck);
            Console.WriteLine("{0} is prime.", numberForCheck);
        }
        catch (NotPrimeNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
