////
namespace H08SentencesContainingGivenWord
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

   public class SentencesContainingGivenWord
    {
       private static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have, in, anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            int start = 0;
            int end = text.IndexOf('.');

            string sentence = text.Substring(start, end + 1);
            string word = "in";
            word = "\\b" + word + "\\b";
            bool isMatch = Regex.IsMatch(sentence, word);
            
            if (isMatch)
            {
                Console.WriteLine(sentence);
            }

            start = 1;
            text = text.Substring(end + 1);
            end = text.IndexOf('.');

            while (end > -1)
            {                
                sentence = text.Substring(start, end);
                text = text.Substring(end + 1);
                isMatch = Regex.IsMatch(sentence, word);

                if (isMatch)
                {
                    Console.WriteLine(sentence);
                }

                end = text.IndexOf('.');
            }
        }
    }
}
