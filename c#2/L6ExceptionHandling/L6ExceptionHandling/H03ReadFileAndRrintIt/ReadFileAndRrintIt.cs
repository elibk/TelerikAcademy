////
namespace H03ReadFileAndRrintIt
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

   public class ReadFileAndRrintIt
    {
       private static void Main(string[] args)
        {
            StreamReader reader; 
            try
            {
                reader = new StreamReader(@"D:\c#2\L6ExceptionHandling\L6ExceptionHandling\L6ExceptionHandling.sln", Encoding.GetEncoding("windows-1251"));
                using (reader)
                {
                    Console.WriteLine(reader.ReadToEnd());   
                }             
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
                Console.WriteLine("Sorry,the file can not be open.");
            }    
        }
    }
}
