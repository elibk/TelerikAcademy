////
namespace H07ConvertToNumeralSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class ConvertToNumeralSystem
    {
       private static void Main(string[] args)
        {
            int systemBase = int.Parse(Console.ReadLine()),
                newSystemBase = int.Parse(Console.ReadLine());

            string numInSomeSystem = "11100";

            int decimalNum = new int { };

            for (int i = numInSomeSystem.Length - 1, numPosition = 0; i >= 0; i--, numPosition++)
            {
                if (numInSomeSystem[numPosition] >= 65)
                {
                    decimalNum += (int)Math.Pow(systemBase, (double)i) * ((int)numInSomeSystem[numPosition] - 55);
                }
                else
                {
                    decimalNum += (int)Math.Pow(systemBase, (double)i) * ((int)numInSomeSystem[numPosition] - 48);
                }
            }

            List<int> digits = new List<int> { };

            while (decimalNum != 0)
            {
                digits.Add(decimalNum % newSystemBase);

                decimalNum = decimalNum / newSystemBase;
            }

            string numInNewNumSystem = string.Empty;

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (digits[i] > 9)
                {
                    numInNewNumSystem += (char)(digits[i] + 55);
                }
                else
                {
                    numInNewNumSystem += digits[i];
                }
            }

            Console.WriteLine(numInNewNumSystem);  
        }
    }
}
