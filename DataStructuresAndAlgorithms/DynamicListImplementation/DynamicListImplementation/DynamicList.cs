using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicListImplementation
{
    public class DynamicList<T> : IList<T>
        where T: IEquatable<T>
    {
       private T element;

       private Node<T> tail;
       private Node<T> head;
       private int count;

       public DynamicList()
       { 
            
       }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
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

        public T RemoveLast() 
        {
            if (this.count == 0)
            {
                throw new IndexOutOfRangeException("Can not remove element of empty list.");
            }

            T lastElement = this.tail.Element;

            this.tail = this.tail.Previous;

            if (this.tail != null)
            {
                this.tail.Next = null; 
            }
            
            this.count--;

            if (this.Count == 0)
            {
                this.head = null;
            }
            return lastElement;
        }

        public T RemoveByIndex(int index)
        {
            if ( index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounce of the array.");
            }

            if (index == this.Count - 1)
            {
               return this.RemoveLast();
            }

            int currentIndex = 0;
            Node<T> currnetNodeToBeRemoved = this.head;

            while (currentIndex < index)
            {
                currentIndex++;
                currnetNodeToBeRemoved = currnetNodeToBeRemoved.Next;
            }

            if (currnetNodeToBeRemoved.Previous == null)
            {
                this.head = currnetNodeToBeRemoved.Next;
            }
            else
            {
                currnetNodeToBeRemoved.Previous.Next = currnetNodeToBeRemoved.Next;
            }

            currnetNodeToBeRemoved.Next.Previous = currnetNodeToBeRemoved.Previous;
            this.count--;
            return currnetNodeToBeRemoved.Element;
        }

        public int IndexOf(T item)
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

        public void RemoveAt(int index)
        {
            RemoveByIndex(index);
        }

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            int itemIndex = this.IndexOf(item);
            if (itemIndex >= 0)
            {
                this.RemoveAt(itemIndex);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
