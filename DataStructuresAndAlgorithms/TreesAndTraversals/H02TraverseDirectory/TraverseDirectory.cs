namespace H02TraverseDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

   public class TraverseDirectory
    {
       public static void Main(string[] args)
        {
           // this might take a while for the test better use other path
            string rootDirectory = @"C:\Windows";
          
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(rootDirectory);
            var spaces = " ";

            while (directories.Count > 0)
            {
                try
                {
                    var sourceDirectory = directories.Dequeue();
                    Console.Write(spaces);
                    Console.WriteLine('<' + sourceDirectory + '>');
                    var exeFoiles = Directory.EnumerateFiles(sourceDirectory, "*.exe");
                    foreach (string currentFile in exeFoiles)
                    {
                        string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                        Console.Write(spaces + "->");
                        Console.WriteLine(fileName);
                    }

                    var subdirectories = Directory.EnumerateDirectories(sourceDirectory);
                    foreach (var subDirectoy in subdirectories)
                    {
                        directories.Enqueue(subDirectoy);
                    }

                    spaces += " ";
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}