using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H12RemoveListOfWords
{
    class RemoveListOfWords
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader reader = new StreamReader(@"...\...\SomeText.txt", Encoding.GetEncoding("windows-1251"));
                StreamWriter writer = new StreamWriter(@"...\...\output.txt", false, Encoding.GetEncoding("windows-1251"));
                StreamReader readerList = new StreamReader(@"...\...\ListOfWords.txt", Encoding.GetEncoding("windows-1251"));

                List<string> words = ReadListOfWords(readerList);

                RemoveWords(reader, writer, words);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Sorry, the given path is too long.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Sorry,the directory of the file was not found.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Sorry, file was not found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Sorry,the file can't be loaded");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("Sorry,access denied");
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Sorry,the conection with the file was broken. If you file is on external device, check if it's correctly plugged.");
            }
            catch (IOException)
            {
                Console.WriteLine("Sorry,the file cannot be open.");
            }    
        }

        private static void RemoveWords(StreamReader reader, StreamWriter writer, List<string> words)
        {
            string line = string.Empty;
            using (reader)
            {
                using (writer)
                {
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        for (int i = 0; i < words.Count; i++)
                        {
                            string replace = "\\b" + words[i] + "\\b";

                            line = Regex.Replace(line, replace, string.Empty);
                        }


                        writer.WriteLine(line);
                    }
                }
            }

            File.Replace(@"...\...\output.txt", @"...\...\SomeText.txt", @"...\...\backup.txt");
        }

        private static List<string> ReadListOfWords(StreamReader readerList)
        {
            List<string> words = new List<string>();
            string word = string.Empty;

            using (readerList)
            {
                while (true)
                {
                    word = readerList.ReadLine();

                    if (word == null)
                    {
                        break;
                    }
                    words.Add(word);
                }

            }
            return words;
        }
    }
}
