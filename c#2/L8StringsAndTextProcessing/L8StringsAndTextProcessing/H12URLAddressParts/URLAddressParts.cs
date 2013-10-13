////
namespace H12URLAddressParts
{
    using System;
    using System.Linq;

   public class URLAddressParts
    {
       private static void Main(string[] args)
        {
            string url = "http://www.devbg.org/forum/index.php";

            string protocol = string.Empty,
                   server = string.Empty,
                   resource = string.Empty;

            protocol = url.Substring(0, url.IndexOf(':'));
            url = url.Substring(protocol.Length + 3);
            server = url.Substring(0, url.IndexOf('/'));
            resource = url.Substring(server.Length);
            Console.WriteLine(@"[protocol] = ""{0}""", protocol);
            Console.WriteLine(@"[server] = ""{0}""", server);
            Console.WriteLine(@"[resource] = ""{0}""", resource);
        }
    }
}
