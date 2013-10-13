////
namespace H06Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

   public class Phonebook
    {
       private const string EnriesPath = "phones.txt";
       private const string CommandPath = "commands.txt";

       public static void Main(string[] args)
        {
            // needed to display the report right
            Console.WindowWidth = 80;

            PhonebookRepository repository = new PhonebookRepository();

            StreamReader enriesReader = new StreamReader(EnriesPath);

            using (enriesReader)
            {
                string line = enriesReader.ReadLine();
                while (line != null)
                {
                    PhonebookEntry currentEntry = PhonebookEntry.Parse(line);
                    repository.AddEntry(currentEntry);
                    line = enriesReader.ReadLine();
                }
            }

            StreamReader commandsReader = new StreamReader(CommandPath);

            using (commandsReader)
            {
                Console.WriteLine(new string('_', Console.WindowWidth));
                string line = commandsReader.ReadLine();
                while (line != null)
                {
                   var report = ParseCommand(line, repository);

                   if (report.Count() != 0)
                   {
                       foreach (var item in report)
                       {
                           Console.WriteLine(item);
                       }

                       Console.WriteLine(new string('_', Console.WindowWidth));
                   }
                   else
                   {
                       Console.WriteLine("No information found.");
                       Console.WriteLine(new string('_', Console.WindowWidth));
                   }
                 
                   line = commandsReader.ReadLine();
                }
            }
        }

        private static IEnumerable<PhonebookEntry> ParseCommand(string line, PhonebookRepository repository)
        {
           int commandEndIndex = line.IndexOf('(');

            if (commandEndIndex == -1)
            {
                throw new ArgumentException("Invalid command input");
            }

            string command = line.Substring(0, commandEndIndex);

            string commandParameters = line.Substring(commandEndIndex + 1, line.Length - commandEndIndex - 2);
            string[] listOfCommandParameters = commandParameters.Split(',');

            for (int i = 0; i < listOfCommandParameters.Length; i++)
            {
                listOfCommandParameters[i] = listOfCommandParameters[i].Trim();
            }

            if (command != "find")
            {
                 throw new ArgumentException("Invalid command input");
            }

            IEnumerable<PhonebookEntry> result;

            if (listOfCommandParameters.Length == 1)
            {
                result = repository.Find(listOfCommandParameters[0]);
            }
            else if (listOfCommandParameters.Length == 2)
            {
                result = repository.Find(listOfCommandParameters[0], listOfCommandParameters[1]);
            }
            else
            {
                throw new ArgumentException("Invalid lenght of command parameters.");
            }

            return result;
        }
    }
}
