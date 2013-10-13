////
namespace H12IndexOfLettersInWord
{
    using System;
    using System.Linq;

    public class IndexOfLettersInWord
    {
        private static void Main(string[] args)
        {
            char[] alphabet = new char[26];
            
            for (int i = 0, letter = 'A'; i < alphabet.Length; i++, letter++)
            {
                alphabet[i] = (char)letter;
            }

            Console.Write("Enter some word:");
            string word = Console.ReadLine();
            Console.WriteLine(word);
            foreach (var letter in word)
            {
                Console.Write("\"{0}\" is with ", letter);
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == letter)
                    {
                        Console.WriteLine(@"index ""{0}"".", i);
                    }
                }              
            }
        }
    }
}
