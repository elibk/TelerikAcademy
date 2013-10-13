using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H03ExtractingArtistsDOM
{
    class XPath
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalogue.xml");
            XmlNode rootNode = xmlDoc.DocumentElement;
            Dictionary<string, int> artistDict = new Dictionary<string, int>();
            string xPathQuery = "catalogue/album";
            XmlNodeList artistList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode artist in artistList)
            {
                string artistName = artist.SelectSingleNode("artist").InnerText;

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
