////
namespace H07ReverseDigits
{
    using System;
    using System.Linq;

  public class ReverseDigits
    {
      private static void Reverse(ref string number)
        {
            string reversed = string.Empty;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                reversed += number[i];
            }
        
            for (int i = 0; i < reversed.Length; i++)
            {
                if (reversed[i] != '0')
                {
                    reversed = reversed.Substring(i);
                    break;
                }
            }

            number = reversed;
        }

       private static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Reverse(ref number);
            Console.WriteLine(number);
        }
    }
}
