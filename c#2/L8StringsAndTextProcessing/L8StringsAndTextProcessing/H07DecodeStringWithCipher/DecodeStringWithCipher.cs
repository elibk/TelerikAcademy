////
namespace H07DecodeStringWithCipher
{
    using System;
    using System.Linq;
    using System.Text;

   public class DecodeStringWithCipher
    {
       private static void Main(string[] args)
        {
            string text = "hi!";
            string key = "ab";
            text = Decode(text, key);
            Console.WriteLine(text);
            Console.WriteLine(ConvertToLiterals(text));
            text = Decode(text, key);
            Console.WriteLine(text);
        }

        private static string Decode(string text, string key)
        {
            char[] cript = new char[text.Length];

            for (int i = 0, indKey = 0; i < text.Length; i++, indKey++)
            {
                cript[i] = (char)(text[i] ^ key[indKey]);

                if (indKey == key.Length - 1)
                {
                    indKey = -1;
                }
            }

            return ArrayToString(ref text, cript);
        }

        private static string ArrayToString(ref string text, char[] cript)
        {
            StringBuilder stringer = new StringBuilder();

            stringer.Append(cript);
            text = stringer.ToString();
            return text;
        }

        private static string ConvertToLiterals(string input)
        {
            StringBuilder strBild = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                strBild.Append(@"\u" + Convert.ToString((int)input[i], 16).PadLeft(4, '0'));
            }

            string output = strBild.ToString();
            return output;
        }
    }
}
