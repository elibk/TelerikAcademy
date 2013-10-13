using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08LinkedOut
{
    class Program
    {
        private static Dictionary<string, HashSet<string>> adjList = new Dictionary<string, HashSet<string>>();
       
        static void Main(string[] args)
        {
            var person = Console.ReadLine();
            adjList.Add(person, new HashSet<string>());

            var conectionsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < conectionsCount; i++)
            {
                FillAdjList(Console.ReadLine());
            }

            var conectionsToBeCalc = int.Parse(Console.ReadLine());

            for (int i = 0; i < conectionsToBeCalc; i++)
            {
                Console.WriteLine(CalcConection(person,Console.ReadLine()));
            }

        }

        private static void FillAdjList(string conection)
        {

            var conections = conection.Split(new char[]{' '});
            if (!adjList.ContainsKey(conections[0]))
	        {
                adjList.Add(conections[0], new HashSet<string>());
	        }

            adjList[conections[0]].Add(conections[1]);

            if (!adjList.ContainsKey(conections[1]))
            {
                adjList.Add(conections[1], new HashSet<string>());
            }

            adjList[conections[1]].Add(conections[0]);
            
        }

        private static int CalcConection(string person, string connectedPerson)
        {
            Queue<string> people = new Queue<string>();
            HashSet<string> visitedPeoople = new HashSet<string>();

            var nodesInNextLayer = 0;
            var nodesInThisLayer  = 1;
            people.Enqueue(person);
            var conectionLevel = 1;
            while (people.Count > 0)
            {
                if (!adjList.ContainsKey(connectedPerson))
                {
                    return -1;
                }
                var currentPerson = people.Dequeue();
                
                if (visitedPeoople.Contains(currentPerson))
                {
                    if (0 == --nodesInThisLayer)
                    {
                        nodesInThisLayer = nodesInNextLayer;
                        nodesInNextLayer = 0;
                        conectionLevel++;
                    } 
                    continue;
                }

                HashSet<string> personConections = adjList[currentPerson];
                if (personConections.Contains(connectedPerson))
                {
                    return conectionLevel;
                }

                visitedPeoople.Add(currentPerson);

                foreach (var friend in personConections)
                {
                    people.Enqueue(friend);
                    ++nodesInNextLayer;
                }

                if (0 == --nodesInThisLayer)
                {
                    nodesInThisLayer = nodesInNextLayer;
                    nodesInNextLayer = 0;
                    conectionLevel++;
                } 
            }

            return -1;
        }
    }
}
