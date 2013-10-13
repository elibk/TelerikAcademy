using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2ANacci
{
    class ANacci
    {
        static void Main(string[] args)
        {
            int firstLetter = (char.Parse(Console.ReadLine())) - 64;
            int secondLetter = (char.Parse(Console.ReadLine())) - 64;
            int L = int.Parse(Console.ReadLine());

            int[] eiNacci = new int[L*2 -1];
            int[] numsForCalculation = new int[3];

            if (L == 1)
            {
                Console.WriteLine((char)(firstLetter+64));
            }
            else
            {
                eiNacci[0] =  numsForCalculation[0] = firstLetter;
                eiNacci[1] = numsForCalculation[1] = secondLetter;
                for (int i = 2; i < eiNacci.Length; i++ )
                {
                    if (numsForCalculation[0] + numsForCalculation[1] < 27)
                    {
                        numsForCalculation[2] = numsForCalculation[0] + numsForCalculation[1];
                    }
                    else
                    {
                        numsForCalculation[2] = (numsForCalculation[0] + numsForCalculation[1]) % 26;
                    }
                    eiNacci[i] = numsForCalculation[2];
                    numsForCalculation[0] = numsForCalculation[1];
                    numsForCalculation[1] = numsForCalculation[2];
                    
                }
                Console.WriteLine((char)(eiNacci[0] + 64));

                for (int i = 1, whitespaces = 0, lines = 2; lines <= L; i += 2, whitespaces++, lines++)
                {
                    Console.WriteLine((char)(eiNacci[i] + 64) + new string(' ', whitespaces) + (char)(eiNacci[i + 1] + 64));
                }
            }      
        }
    }
}
