namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor
    {
        private IPhonebookRepository repository;
        private StringBuilder output;

        public CommandExecutor(IPhonebookRepository repository) 
        {
            this.Repository = repository;
            this.output = new StringBuilder();
        }

        public IPhonebookRepository Repository
        {
            get
            {
                return this.repository;
            }

            private set
            {
                this.repository = value;
            }
        }

        public StringBuilder Output
        {
            get
            {
                return this.output;
            }

            private set
            {
                this.output = value;
            }
        }

        public void ExecuteCommand(string line)
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

            switch (command)
            {
                case "AddPhone":
                    this.PerformAddNumber(listOfCommandParameters);
                    break;
                case "ChangePhone":
                    this.PerformChnagePhone(listOfCommandParameters);
                    break;
                case "List":
                    this.PerformList(listOfCommandParameters);
                    break;
                default:
                    throw new ArgumentException(string.Format("Invalid command '{0}'", command));
            }
        }

        private void PerformList(string[] listOfCommandParameters)
        {
            try
            {
                int startIndex = int.Parse(listOfCommandParameters[0]);
                int countOfEntries = int.Parse(listOfCommandParameters[1]);
                IEnumerable<Contact> entries = this.repository.ListEntries(startIndex, countOfEntries);
                foreach (var entry in entries)
                {
                    this.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.Print("Invalid range");
            }
        }
                
        private void PerformChnagePhone(string[] listOfCommandParameters)
        {
            string oldNumber = PhoneNumberAdaptor.ParseToAdaptedPhoneNumber(listOfCommandParameters[0]);
            string newNumber = PhoneNumberAdaptor.ParseToAdaptedPhoneNumber(listOfCommandParameters[1]);
            this.Print(this.repository.ChangePhone(oldNumber, newNumber) + " numbers changed");
        }
                
        private void PerformAddNumber(string[] listOfCommandParameters)
        {
            string contactName = listOfCommandParameters[0];
            var contactNumbers = listOfCommandParameters.Skip(1).ToList();

            for (int i = 0; i < contactNumbers.Count; i++)
            {
                contactNumbers[i] = PhoneNumberAdaptor.ParseToAdaptedPhoneNumber(contactNumbers[i]);
            }

            bool isContactExists = this.repository.AddPhone(contactName, contactNumbers);

            if (isContactExists)
            {
                this.Print("Phone entry merged");
            }
            else
            {
                this.Print("Phone entry created");
            }
        }
                
        private void Print(string text)
        {
            this.output.AppendLine(text);
        }
    }
}
