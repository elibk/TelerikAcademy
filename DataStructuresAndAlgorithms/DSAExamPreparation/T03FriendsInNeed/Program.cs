using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T03FriendsInNeed
{
    public class Dijkstra
    {
        static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            OrderedBag<Node> queue = new OrderedBag<Node>();

            foreach (var node in graph)
            {
                if (source.ID != node.Key.ID)
                {
                    node.Key.DijkstraDistance = double.PositiveInfinity;
                    queue.Add(node.Key);
                }
            }

            source.DijkstraDistance = 0.0d;
            queue.Add(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.GetFirst();

                if (currentNode.DijkstraDistance == double.PositiveInfinity)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    double potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potDistance;
                        Node next = new Node(neighbour.Node.ID, potDistance);
                        queue.Add(next);
                    }
                }

                queue.RemoveFirst();
            }
        }
        static HashSet<Node> hospitals;
        static void Main()
        {

            string[] data = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int numberOfPoints = int.Parse(data[0]);
            int numberOfStreets = int.Parse(data[1]);
            int numberOfHospitals = int.Parse(data[2]);
            List<Node> nodes = new List<Node>();
            Dictionary<Node, List<Connection>> points = new Dictionary<Node, List<Connection>>();
            for (int i = 1; i <= numberOfPoints; i++)
			{
                var newNode = new Node(i);
                nodes.Add(newNode);
                points.Add(newNode, new List<Connection>());
			}

            string[] hospitalsData = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
             hospitals = new HashSet<Node>();
            for (int i = 0; i < numberOfHospitals; i++)
			{
                hospitals.Add(nodes[int.Parse(hospitalsData[i])-1]);
			}

            for (int i = 0; i < numberOfStreets; i++)
			{

                string[] connectionData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;
                
                Node firstNode = nodes[int.Parse(connectionData[0])- 1];
                Node secondNode = nodes[int.Parse(connectionData[1])- 1];

                Connection newConectedNode = new Connection(secondNode, double.Parse(connectionData[2]));
                Connection secondConectedNode = new Connection(firstNode, double.Parse(connectionData[2]));

                points[firstNode].Add(newConectedNode);
                points[secondNode].Add(secondConectedNode);

			}

            double distance = double.PositiveInfinity;
            
           // bool[] visited = new bool[numberOfPoints];
            foreach (var hospital in hospitals)
            {
               double currentdistance = 0;
                DijkstraAlgorithm(points, hospital);

                foreach (var item in points)
                {
                    if (!hospitals.Contains(item.Key))
                    {
                        currentdistance += item.Key.DijkstraDistance;
                    }
                }

                if (currentdistance < distance)
                {
                    distance = currentdistance;
                }

               // visited = new bool[numberOfPoints];
            }
            Console.WriteLine(distance);

            //foreach(var item in points)
            //{
            //    Console.Write("Distance from {0} to {1} ", hospitals[0].ID, item.Key.ID);
            //    Console.WriteLine(item.Key.DijkstraDistance);
            //}
           
        }

        //private static void TraverseNode(Dictionary<Node, List<Connection>> graph, Node source, bool[] visited)
        //{
        //    if (visited[source.ID - 1])
        //    {
        //        return;
        //    }
        //    visited[source.ID - 1] = true;
        //    if (!hospitals.Contains(source))
        //    {
        //        currentdistance += source.DijkstraDistance;
        //    }
            
        //    foreach (var item in graph[source])
        //    {
        //        TraverseNode(graph,item.Node,visited);
        //    }
        //}
    }

    public class Connection
    {
        public Node Node { get; set; }
        public double Distance { get; set; }

        public Connection(Node node, double distance)
        {
            this.Node = node;
            this.Distance = distance;
        }
    }

    public class Node : IComparable, IEquatable<Node>
    {
        public int ID { get; private set; }
        public double DijkstraDistance { get; set; }

        public Node(int id, double dicstra = 0)
        {
            this.ID = id;
            DijkstraDistance = dicstra;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.ID == other.ID)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.ID.ToString();
        }
    }
}
