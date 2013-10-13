using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1SevenlandNumbers
{
    class SevenlandNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numString = Convert.ToString(number + 1).PadLeft(4, '0');

            char firstDigit = numString[0],
                secondDigit = numString[1],
                thirdDigit = numString[2],
                lastDigit = numString[3];

            if (lastDigit == '7')
            {
                lastDigit = '0';
                thirdDigit++;
            }
            if (thirdDigit == '7')
            {
                thirdDigit = '0';
                secondDigit++;
            }
            if (secondDigit == '7')
            {
                secondDigit = '0';
                firstDigit++;
            }

            numString = (""+ firstDigit) +(""+secondDigit) + (""+thirdDigit) + lastDigit;

            number = int.Parse(numString);
            Console.WriteLine(number);
        }
    }
}
