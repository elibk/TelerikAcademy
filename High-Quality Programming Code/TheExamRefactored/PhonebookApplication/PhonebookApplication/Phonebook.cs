namespace PhonebookApplication
{
    using System;
    using System.Linq;

    public class Phonebook
    {
        internal static void Main()
        {
            CommandExecutor commandExecutor = new CommandExecutor(new PhonebookRepositoryOriginal()); 

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End" || line == null)
                { 
                    break;
                }

                commandExecutor.ExecuteCommand(line);
            }

            Console.Write(commandExecutor.Output);
        }
    }
}
