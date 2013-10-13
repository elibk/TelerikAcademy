////
namespace H04DownloadFile
{
    using System;
    using System.Linq;
    using System.Net;

   public class DownloadFile
    {
       private static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            string site = "http://telerikacademy.com/Contdent/Users/Profiles/Images/userAvatarWoman.jpg";
            string path = @"d:\myAvatar.jpg";
            try
            {
                using (webClient)
                {
                    webClient.DownloadFile(site, path);
                }
            }
            catch (WebException ex)
            {
                if (ex.InnerException != null)
                {
                    Exception inner = ex.InnerException;
                    string exeptionType = inner.GetType().ToString();
                    switch (exeptionType)
                    {
                        case "System.IO.DirectoryNotFoundException":
                            Console.WriteLine("Sorry, path {0} was not found.", path);
                            break;
                        case "System.UnauthorizedAccessException":
                            Console.WriteLine("Sorry, you are not authorizet to follow path.", path);
                            break;
                        default:
                            Console.WriteLine("An exeption {0} cause WebExeption", exeptionType);
                            Console.WriteLine(inner.Message);
                            break;
                    }
                }
                else
                {
                    if (ex.Message == "The remote server returned an error: (404) Not Found.")
                    {
                        Console.WriteLine("A directory or the file from path {0} was not found.", site);
                    }
                    else
                    {
                        Console.WriteLine("An error occured while trying to connect the network. Please,check you internet conection or check the name of the site");
                    }
                }
            }
            finally
            {
                webClient.Dispose();
            }
        }
    }
}
