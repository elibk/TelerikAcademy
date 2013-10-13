using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H15ReplaceUrlsInHtml
{
    class ReplaceUrlsInHtml
    {
        static void Main(string[] args)
        {
            string html = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

            string output = Regex.Replace(html, @"<a href=""", "[URL=");
            output = Regex.Replace(output, @""">", "]");
            output = Regex.Replace(output, @"</a>", "[/URL]");

            Console.WriteLine(output);
        }
    }
}