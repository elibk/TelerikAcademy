using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T03SupermarketQueue
{
    class Program
    {
        private static SupermarketQueue repository;
        private static StringBuilder output;
        static void Main(string[] args)
        {
            output = new StringBuilder();
            repository = new SupermarketQueue();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
               ParseCommand(line);

            }


           // Console.WriteLine("Test");
            Console.WriteLine(output);
        }

        private static void ParseCommand(string command)
        {
            string[] data = command.Split(new char[] { ' ' }, 2);
            string commandName = data[0];
            string[] commandParameters = data[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            switch (commandName)
            {
                case "Append":
                    repository.Apppend(commandParameters[0]);
                    output.AppendLine("OK");
                    break;
                case "Insert":
                    {
                        string result = repository.Insert(int.Parse(commandParameters[0]), commandParameters[1]);
                        output.AppendLine(result);
                    }
                    break;
                case "Find":
                    {
                       int result = repository.Find(commandParameters[0]);
                        output.AppendLine(result.ToString());
                    }
                    break;
                case "Serve":
                    {
                       string result = repository.Serve(int.Parse(commandParameters[0]));
                       output.AppendLine(result);
                    }
                    break;

                default:
                    throw new InvalidOperationException("Invalid command");
            }
        }

        public class SupermarketQueue
        {
            private Deque<string> queue;
            private Dictionary<string, int> peopleInQueue;

            public SupermarketQueue()
            {
                this.queue = new Deque<string>();
                this.peopleInQueue = new Dictionary<string, int>();
            }

            public void Apppend(string name)
            {
                queue.AddToBack(name);
                if (!peopleInQueue.ContainsKey(name))
                {
                    peopleInQueue.Add(name, 0);
                }

                peopleInQueue[name]++;
            }

            public string Insert(int position, string name)
            {
                if (position > queue.Count || position < 0)
                {
                    return "Error";
                }

                if (position == queue.Count)
                {
                    this.Apppend(name);
                    return "OK";
                }

                queue.Insert(position, name);

                if (!peopleInQueue.ContainsKey(name))
                {
                    peopleInQueue.Add(name, 0);
                }
                peopleInQueue[name]++;
                return "OK";
            }

            public int Find(string name)
            {

                if (!peopleInQueue.ContainsKey(name))
                {
                    return 0;
                }

                return peopleInQueue[name];
            }

            public string Serve(int count)
            {
                if (count > queue.Count || count <= 0)
                {
                    return "Error";
                }
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    var name = queue.RemoveFromFront();
                    peopleInQueue[name]--;
                    result.Append(name);
                    result.Append(' ');
                }

                result.Length--;

                return result.ToString();
            }


        }

        public class LinkedQueue<T>
        {
            private Node<T> tail;
            private Node<T> head;
            private int count;

            public LinkedQueue()
            {
            }

            public int Count
            {
                get
                {
                    return this.count;
                }
            }

            public T Peek()
            {
                if (this.count == 0)
                {
                    throw new IndexOutOfRangeException("The Queue is empty.");
                }

                T firstElement = this.head.Element;

                return firstElement;
            }

            public void Enqueue(T element)
            {
                if (this.head == null)
                {
                    this.head = new Node<T>(element);
                    this.tail = this.head;
                }
                else
                {
                    var newNode = new Node<T>(element, null, this.tail);
                    this.tail = newNode;
                }

                this.count++;
            }

            public T Dequeue()
            {
                if (this.count == 0)
                {
                    throw new IndexOutOfRangeException("The Queue is empty.");
                }

                T firstElement = this.head.Element;

                this.head = this.head.Next;

                if (this.head != null)
                {
                    this.head.Previous = null;
                }

                this.count--;

                if (this.count == 0)
                {
                    this.tail = null;
                }

                return firstElement;
            }

            public void Clear()
            {
                this.head = null;
                this.tail = null;
                this.count = 0;
            }

            public bool Contains(T item)
            {
                if (this.IndexOf(item) >= 0)
                {
                    return true;
                }

                return false;
            }

            private int IndexOf(T item)
            {
                int currentIndex = 0;
                Node<T> currnetNodeToBeRemoved = this.head;

                while (currentIndex < this.Count)
                {
                    if (currnetNodeToBeRemoved.Element.Equals(item))
                    {
                        return currentIndex;
                    }

                    currentIndex++;
                    currnetNodeToBeRemoved = currnetNodeToBeRemoved.Next;
                }

                return -1;
            }

            public void Insert(int index, T item)
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                int currentIndex = 0;
                Node<T> currentNode = this.head;

                while (currentIndex < index)
                {
                    currentIndex++;
                    currentNode = currentNode.Next;
                }

                Node<T> newNode = new Node<T>(item, currentNode, currentNode.Previous);

                if (newNode.Previous == null)
                {
                    this.head = newNode;
                }

                if (newNode.Next == null)
                {
                    this.tail = newNode;
                }

                this.count++;
            }
        }

        internal class Node<T>
        {
            private T element;
            private Node<T> next;
            private Node<T> previous;

            public Node(T element, Node<T> next = null, Node<T> prev = null)
            {
                this.Element = element;

                this.next = next;
                if (this.next != null)
                {
                    next.Previous = this;
                }

                this.previous = prev;
                if (this.previous != null)
                {
                    prev.Next = this;
                }
            }

            public T Element
            {
                get
                {
                    return this.element;
                }

                set
                {
                    this.element = value;
                }
            }

            public Node<T> Next
            {
                get
                {
                    return this.next;
                }

                set
                {
                    this.next = value;
                }
            }

            public Node<T> Previous
            {
                get
                {
                    return this.previous;
                }

                set
                {
                    this.previous = value;
                }
            }
        }
    }
}
