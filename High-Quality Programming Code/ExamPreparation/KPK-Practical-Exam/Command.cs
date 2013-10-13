namespace CatalogFreeContent
{
    using System;
    using System.Linq;

    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';
        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        /// <summary>
        /// Parses the type of the command.
        /// </summary>
        /// <param name="commandName">Name of the command.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.ArgumentException">Invalid command name!</exception>
        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    type = CommandType.AddBook;
                    break;
                case "Add movie":
                    type = CommandType.AddMovie;
                    break;
                case "Add song":
                    type = CommandType.AddSong;
                    break;
                case "Add application":
                    type = CommandType.AddApplication;
                    break;
                case "Update":
                    type = CommandType.Update;
                    break;
                case "Find":
                    type = CommandType.Find;
                    break;
                default:
                    throw new ArgumentException("Invalid command name!");
            }

            return type;
        }

        /// <summary>
        /// Parses the name.
        /// </summary>
        /// <returns></returns>
        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        /// <summary>
        /// Parses the parameters.
        /// </summary>
        /// <returns></returns>
        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 2);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 2, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        /// <summary>
        /// Gets the end index of the command name.
        /// </summary>
        /// <returns></returns>
        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd);

            return endIndex;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string toString = string.Empty + this.Name + " ";

            foreach (string param in this.Parameters)
            {
                toString += param + " ";
            }

            return toString;
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
