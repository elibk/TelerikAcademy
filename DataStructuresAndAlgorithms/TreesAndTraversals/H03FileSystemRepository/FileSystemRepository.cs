namespace H03FileSystemRepository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSystemRepository
    {
        public static void Main(string[] args)
        {
            // this might take a while for the test better use other path
            string rootDirectory = @"C:\Windows";

            Queue<string> directories = new Queue<string>();
            Queue<Folder> foldersRepos = new Queue<Folder>();
            directories.Enqueue(rootDirectory);
            var spaces = " ";
            var indexOfDirName = rootDirectory.IndexOf("\\") + 1;
            var rootFolder = new Folder();
            foldersRepos.Enqueue(rootFolder);
            
            while (directories.Count > 0)
            {
                try
                {
                    var sourceDirectory = directories.Dequeue();
                    var sourceDirRep = foldersRepos.Dequeue();
                    var sourceDirName = sourceDirectory.Substring(indexOfDirName);
                    sourceDirRep.Name = sourceDirName;
                    var subFiles = Directory.GetFiles(sourceDirectory, "*.*");
                    
                    foreach (string currentFile in subFiles)
                    {
                        var fileContainer = new FileInfo(currentFile);
                        var fileSize = fileContainer.Length;
                        string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                        sourceDirRep.Files.Add(new File(fileName, fileSize));
                    }

                    var subdirectories = Directory.EnumerateDirectories(sourceDirectory);
                    foreach (var subDirectoy in subdirectories)
                    {
                        directories.Enqueue(subDirectoy);
                        var newFolder = new Folder();
                        foldersRepos.Enqueue(newFolder);

                        sourceDirRep.SubFolders.Add(newFolder);
                    }

                    spaces += " ";
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(rootFolder.CalculateSize() + " bytes.");
        }
    }
}
