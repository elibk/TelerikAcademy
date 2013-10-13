using System;
using System.Linq;

public class Converter
{
   private const int MaxCount = 6;

   public class BoolToStringConverter
    {
        public static void Main()
        {
            Converter.BoolToStringConverter testCoverter = new Converter.BoolToStringConverter();
            testCoverter.PrintToString(true);
        }

        public void PrintToString(bool valueForPrint)
        {
            string convertedBool = valueForPrint.ToString();
            Console.WriteLine(convertedBool);
        }
    }
}
