using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H23ReplaceSequenceOfIdenticalLetters
{
    class ReplaceSequenceOfIdenticalLetters
    {
        static void Main(string[] args)
        {
            string input = "aaaaabbbbbcdddeeeedssaa";
            List<char> letters = new List<char> { input[0] };
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != letters[letters.Count-1])
                {
                    letters.Add(input[i]);
                }
            }

            input = string.Join(string.Empty, letters);

            Console.WriteLine(input);
        }
    }
}
