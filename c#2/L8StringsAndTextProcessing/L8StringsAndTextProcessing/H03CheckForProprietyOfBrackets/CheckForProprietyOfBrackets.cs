////
namespace H03CheckForProprietyOfBrackets
{
    using System;
    using System.Linq;

    public class CheckForProprietyOfBrackets
    {
       private static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool check = CheckBrackets(input);
            Console.WriteLine(check);         
        }

        private static bool CheckBrackets(string input)
        {
            int count = 0;
            bool check = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    count++;
                }
                else if (input[i] == ')')
                {
                    count--;
                }

                if (count < 0)
                {
                    break;
                }
            }

            if (count != 0)
            {
                check = false;
            }

            return check;
        }
    }
}
