using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01MessagesInABottle
{


    class Program
    {
        private static List<string> combination;
        private static Dictionary<string, char> codeLetter;
        private static string[] keys; 
       private static string encodedMessage;
        private static int count = 0;
        private static List<string> output;

        static void Main(string[] args)
        { 
            codeLetter = new Dictionary<string, char>();
            output = new List<string>();
            encodedMessage = Console.ReadLine(); 
             string codeIndicator = Console.ReadLine();
            ParseCodeIndicator(codeIndicator);
            combination = new List<string>();
            //foreach (var item in codeLetter)
            //{
            //    Console.WriteLine(item.Value + " -> " + item.Key);
            //}

            //Console.WriteLine(codeLetter.Count);
            
            string currentEnocdesMsg = string.Copy(encodedMessage);

            keys = codeLetter.Keys.ToArray();

            PrintCombinations(currentEnocdesMsg, 0);
            Console.WriteLine(count);

            output.Sort();

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
            
        }

        private static void ParseCodeIndicator(string codeIndicator)
        {
            StringBuilder letterCode = new StringBuilder();
            char currentLetter = codeIndicator[0];
            string code;
            for (int i = 1; i < codeIndicator.Length; i++)
            {

                if (codeIndicator[i] >= '0' && codeIndicator[i] <= '9')
                {
                    letterCode.Append(codeIndicator[i]);
                }
                else
                {

                    code = letterCode.ToString();
                    letterCode.Clear();
                    codeLetter.Add(code, currentLetter);
                    currentLetter = codeIndicator[i];
                }
            }

            code = letterCode.ToString();

            codeLetter.Add(code,currentLetter);
       
        }

        private static void PrintCombinations(string currentEnocdesMsg, int index) 
        {
            if (currentEnocdesMsg.Length == 0)
            {
                if (combination.Count > 0)
                {
                    count++;
                }
                currentEnocdesMsg = string.Copy(encodedMessage);
                StringBuilder str = new StringBuilder();
                foreach (var item in combination)
                {
                    str.Append(item);
                }
                output.Add(str.ToString());
               
                return;
            }

            for (int i = 0; i < keys.Length; i++)
            {
                if (currentEnocdesMsg.StartsWith(keys[i]))
                {
                    combination.Add(codeLetter[keys[i]].ToString());
                    currentEnocdesMsg = currentEnocdesMsg.Remove(0, keys[i].Length);
                    
                    PrintCombinations(currentEnocdesMsg, i + 1);
                    currentEnocdesMsg = keys[i] + currentEnocdesMsg;
                    combination.RemoveAt(combination.Count -1);
                   
                }
            }
        }
    }
}
