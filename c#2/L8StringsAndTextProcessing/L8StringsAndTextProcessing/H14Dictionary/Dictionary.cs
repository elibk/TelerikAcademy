////
namespace H14Dictionary
{
    using System;
    using System.Linq;

   public class Dictionary
    {
       private static readonly string[] definitions = { ".NET", "CLR", "namespace" };

       private static readonly string[] definitionsData = 
        { 
            "platform for applications from Microsoft",
            "managed execution environment for .NET", 
            "hierarchical organization of classes" 
         };

       private static void Main(string[] args)
        {
            string input = Console.ReadLine();

            GetFromDictionary(input);
        }

        private static void GetFromDictionary(string input)
        {
            int indexOfinput = Array.FindIndex(definitions, p => p.Equals(input, StringComparison.CurrentCultureIgnoreCase));

            if (indexOfinput >= 0)
            {
                Console.WriteLine("{12} - {1}", definitions[indexOfinput], definitionsData[indexOfinput]);
            }
            else
            {
                Console.WriteLine("Sorry, the word can not be found.");
            }
        }
    }
}
