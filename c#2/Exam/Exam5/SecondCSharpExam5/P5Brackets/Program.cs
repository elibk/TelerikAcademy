using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P5Brackets
{
    class Program
    {
        static string input = "???????????????????????????????????????";
        //static string input = Console.ReadLine();
        static char[] brackets = { '(', ')' };
        private static readonly int sequanceLen = input.Length;
        private static readonly List<char> Combinations = new List<char>();
        private static readonly List<string> ValidCombinations = new List<string>();
        static BigInteger count = 0;
        static int countBrack = 0;

        private static void Variations(int index)
        {

            if (index == sequanceLen)
            {
                
                if (CheckBrackets(Combinations))
                {
                    //Console.Write("{");
                    //foreach (var item in Combinations)
                    //{
                    //    Console.Write(item);
                    //}

                    //Console.WriteLine("}");

                    count++;
                }

                
            }
            else
            {
                
                for (int number = 0; number < brackets.Length; number++)
                {
                   
                    if (input[index] == '?')
                    {
                        Combinations.Add(brackets[number]);  
                    }
                    else
                    {
                        Combinations.Add(input[index]);
                    }
                    Variations(index + 1);
                    
                }
            }
        }

        private static void Main(string[] args)
        {
            int index = 0;
            Variations(index);
            CountBrackets(input);
            if (countBrack != 0)
            {
                Console.WriteLine(count / (countBrack * countBrack));
            }
            else if (countBrack == 0)
            {
                Console.WriteLine(count);
            }
            
            //Console.WriteLine(countBrack);
        }

        private static void CountBrackets(string input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    countBrack++;

                }
                else if (input[i] == ')')
                {
                    countBrack++;
                }
            }
        }

        private static bool CheckBrackets(List<char> combination)
        {
            int counter = 0;
            bool check = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    counter++;
                }
                else if (input[i] == ')')
                {
                    counter--;
                }

                if (counter < 0)
                {
                    break;
                }
            }

            if (counter != 0)
            {
                check = false;
            }

            return check;
        }
    }
}
