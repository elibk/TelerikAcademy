using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main(string[] args)
        {
            ulong systemBase = 168;

            string durankulakNum = Console.ReadLine();

            string[] durankulakSystem = new string[systemBase];

            for (int i = 0, letter = 65; i < 26; i++, letter++)
            {
                durankulakSystem[i] = ((char)letter) + string.Empty;

            }
            for (int i = 26, smalletter = 97; i < durankulakSystem.Length - 26; i += 26, smalletter++)
            {
                for (int ind = i, bigLetter = 0; ind < i + 26; ind++, bigLetter++)
                {
                    durankulakSystem[ind] = ((char)smalletter) + durankulakSystem[bigLetter];
                }
            }

            for (int ind = 156, bigLetter = 0; ind < (int)systemBase; ind++, bigLetter++)
            {
                durankulakSystem[ind] = 'f' + durankulakSystem[bigLetter];
            }

           

            List<int> digits = new List<int>();

            for (int i = 0; i < durankulakNum.Length; i++)
            {
                if (durankulakNum[i] > 96)
                {
                    i++;
                    digits.Add(Array.IndexOf(durankulakSystem,durankulakNum[i-1] + durankulakNum[i].ToString()));
                }
                else
                {
                    digits.Add(Array.IndexOf(durankulakSystem, durankulakNum[i].ToString()));
                }
            }

            //foreach (var item in digits)
            //{
            //    Console.WriteLine(item);
            //}

            ulong decimalNum = new int();

            for (int i = digits.Count-1, baseMultiplicatior = 0; i >= 0; i--, baseMultiplicatior++)
            {
                decimalNum += (ulong)digits[i] *(ulong)Math.Pow(systemBase, baseMultiplicatior);
            }

            Console.WriteLine(decimalNum);
        }
    }
}
