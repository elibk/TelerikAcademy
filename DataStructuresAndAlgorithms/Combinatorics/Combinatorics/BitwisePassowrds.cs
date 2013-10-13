using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01BitwisePassowrds
{
    class BitwisePassowrds
    {
        static void Main(string[] args)
        {
            string passwordPattern = Console.ReadLine();
            int starsCount = 0;
            for (int i = 0; i < passwordPattern.Length; i++)
            {
                if (passwordPattern[i] == '*')
                {
                    starsCount++;
                }
            }


            ulong combinationsCount = (ulong)Math.Pow(2, starsCount);

            Console.WriteLine(combinationsCount);
        }
    }
}
