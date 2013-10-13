using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H02ExtractingArtistsDOMParser
{
    class DOMParser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artistDict = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artistName = node["artist"].InnerText;

                if (artistDict.ContainsKey(artistName))
                {
                    artistDict[artistName]++;
                }
                else
                {
                    artistDict.Add(artistName, 1);
                }
            }

            foreach (var item in artistDict)
            {
                Console.WriteLine("Artist Name:{0}.{1} Number of Albums -> {2}",
                    item.Key, Environment.NewLine, item.Value);
            }
        }
    }
}
