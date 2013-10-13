////
namespace P1ProvadiaNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProvadiaNumbers
    {
        private static void Main(string[] args)
        {
            ulong newSystemBase = 256;

            ulong decimalNum = ulong.Parse(Console.ReadLine());

            string [] provadiaSystem = new string[256];

            for (int i = 0, letter = 65; i < 26; i++, letter++)
            {
                provadiaSystem[i] = ((char)letter)+ string.Empty;

            }
            for (int i = 26, smalletter = 97; i < provadiaSystem.Length - 26; i+=26, smalletter++)
            {
                for (int ind = i, bigLetter = 0; ind < i + 26; ind++, bigLetter++)
                {
                    provadiaSystem[ind] = ((char)smalletter) + provadiaSystem [bigLetter];
                }
            }

            for (int ind = 234, bigLetter = 0; ind < 256; ind++, bigLetter++)
            {
                provadiaSystem[ind] = 'i' + provadiaSystem[bigLetter];
            }


            if (decimalNum != 0)
            {
                List<ulong> digits = new List<ulong> { };

                while (decimalNum != 0)
                {
                    digits.Add(decimalNum % newSystemBase);

                    decimalNum = decimalNum / newSystemBase;
                }

                StringBuilder numInNewNumSystem = new StringBuilder();

                for (int i = digits.Count - 1; i >= 0; i--)
                {
                    numInNewNumSystem.Append(provadiaSystem[digits[i]]);
                }

                Console.WriteLine(numInNewNumSystem.ToString());
            }
            else
            {
                Console.WriteLine("A");
            }
            

            
            
            
            //foreach (var item in provadiaSystem)
            //{
            //    Console.WriteLine(item);
            //}
            
        }
    }
}
