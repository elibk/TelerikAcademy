////
namespace H11PrintNumberInSeveralFormats
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class PrintNumberInSeveralFormats
    {
       private static void Main(string[] args)
        {
            int number = 16;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine("{0,15:D}", number);
            Console.WriteLine("{0,15:X}", number); ////hexadecimal
            Console.WriteLine("{0,15:P}", number); ////percentage 
            Console.WriteLine("{0,15:E}", number); ////scientific notation
        }
    }
}
