////
namespace JustGenerics
{
    using System;
    using System.Linq;

    public class GenericList<T>
         where T : IComparable<T> 
         ////where T:IEnumerable<T>
    {
        private int capacity = new int();
        private T[] array;
        private int count = new int();

        public GenericList(int capacity)
        {
            this.Capacity = capacity;
        }

        #region properties
        public int Capacity
        {
            get 
            { 
                return this.capacity;
            }

            set
            {
                if (value < this.count)
                {
                    throw new ArgumentException("The value for capacity is smaller than the list size.");
                }

                this.capacity = value;
                this.AutoGrow();
            }
        }

        public int Count
        {
            get { return this.count; }
        }
        #endregion

        #region indexer
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.count)
                {
                    return this.array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index >= 0 && index < this.count)
                {
                    this.array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        #endregion

        #region methods
        public void AddElement(T element)
        {
            if (this.count >= this.capacity)
            {
                this.capacity = this.capacity * 2;
                this.AutoGrow();
            }
            
                this.array[this.count] = element;
                this.count++;    
        }

        ////public T AccessElement(int position)
        ////{
        ////    if (position < 0 || position >= this.capacity)
        ////    {
        ////        throw new IndexOutOfRangeException();
        ////    }

        ////    return this.array[position];
        ////}

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= this.capacity)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index >= this.count)
            {
                Exception emptyPosition = new Exception("There is no object at this position");

                throw emptyPosition;
            }
            else
            {
                T[] arrayNew = new T[this.capacity - 1];

                for (int ind = 0, indNew = 0; ind < this.array.Length; ind++, indNew++)
                {
                    if (ind != index)
                    {
                        arrayNew[indNew] = this.array[ind];
                    }
                    else
                    {
                        indNew--;
                    }
                }

                this.array = arrayNew;
                this.count--;
            }
        }

        public void InsertElement(int postion, T element)
        {
            if (postion < 0 || postion >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T[] arrayNew = new T[this.capacity + 1];

                for (int ind = 0, indNew = 0; ind < this.array.Length; ind++, indNew++)
                {
                    if (indNew != postion)
                    {
                        arrayNew[indNew] = this.array[ind];
                    }
                    else
                    {
                        arrayNew[indNew] = element;
                        ind--;
                    }
                }

                this.array = arrayNew;
                this.count++;
            }
        }

        public void ClearList()
        {
            this.array = new T[this.capacity];
            this.count = 0;
        }

        public int FindElement(T element) 
        {
          ////return  Array.IndexOf(this.array, element);
            
            for (int i = 0; i < this.count; i++)
            {
                if (this.array[i].ToString() == element.ToString())
                {
                    return i;
                }
            }

            return -1;
        }

        public T Max()
        {
            if (this.count <= 0)
            {
                throw new ArgumentNullException("The list is empty.");
            }
            else
            {
                T max = this.array[0];

                for (int i = 0; i < this.count; i++)
                {
                    if (max.CompareTo(this.array[i]) < 0)
                    {
                        max = this.array[i];
                    }
                }

                return max;
            }
        }

        public T Min()
        {
            if (this.count <= 0)
            {
                throw new ArgumentNullException("The list is empty.");
            }
            else
            {
                T min = this.array[0];

                for (int i = 0; i < this.count; i++)
                {
                    if (min.CompareTo(this.array[i]) > 0)
                    {
                        min = this.array[i];
                    }
                }

                return min;
            }
        }

        private void AutoGrow()
        {           
            T[] arrayNew = new T[this.capacity];

            for (int ind = 0; ind < this.count; ind++)
            {
                arrayNew[ind] = this.array[ind];
            }

            this.array = arrayNew;
        }
        #endregion
    }
}
