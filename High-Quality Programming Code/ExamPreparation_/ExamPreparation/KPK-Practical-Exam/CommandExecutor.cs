namespace CatalogFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="catalog">The catalog.</param>
        /// <param name="command">The command.</param>
        /// <param name="sb">The sb.</param>
        /// <exception cref="System.ArgumentException">
        /// Invalid number of parameters!
        /// or
        /// Invalid number of parameters!
        /// or
        /// Unknown command!
        /// </exception>
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new ContentItem(ContentType.Book, command.Parameters)); 
                    sb.AppendLine("Book added");
                    break;

                case CommandType.AddMovie:
                    catalog.Add(new ContentItem(ContentType.Movie, command.Parameters));
                    sb.AppendLine("Movie added");
                    break;

                case CommandType.AddSong:
                    catalog.Add(new ContentItem(ContentType.Song, command.Parameters));
                    sb.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    catalog.Add(new ContentItem(ContentType.Application, command.Parameters));
                    sb.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    if (command.Parameters.Length != 2)
                    {
                        throw new ArgumentException("Invalid number of parameters!");
                    }

                    sb.AppendLine(string.Format("{0} items updated", catalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
                    break;

                case CommandType.Find:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new ArgumentException("Invalid number of parameters!");
                        }

                        int numberOfElementsToList = int.Parse(command.Parameters[1]);

                        IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            sb.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (IContent content in foundContent)
                            {
                                sb.AppendLine(content.TextRepresentation);
                            }
                        }
                    }

                    break;

                default:
                     throw new ArgumentException("Unknown command!");
            }
        }
    }
}
