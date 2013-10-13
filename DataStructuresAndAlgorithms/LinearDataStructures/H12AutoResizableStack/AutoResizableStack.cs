////
namespace H12AutoResizableStack
{
    using System;
    using System.Linq;

    public class AutoResizableStack<T>
    {
        private T[] stack;
       private int count;

        public AutoResizableStack(int capacity = 1) 
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("Value for 'capacity' can not be less than 1");
            }

            this.stack = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.stack.Length;
            }
        }

      public void Push(T element)
      {
          if (this.Capacity < this.Count + 1)
          {
              this.AutoResize();
          }

          this.stack[this.Count] = element;

          this.Count++;
      }

      public T Pop()
      {
          if (this.Count == 0)
          {
              throw new IndexOutOfRangeException("Tha Stack is empty.");
          }

          this.Count--;
          return this.stack[this.Count];
      }

      public T Peek()
      {
          if (this.Count == 0)
          {
              throw new IndexOutOfRangeException("Tha Stack is empty.");
          }
          
          return this.stack[this.Count - 1];
      }

      private void AutoResize()
      {
         T[] newStack = new T[this.Capacity * 2];

         for (int i = 0; i < this.stack.Length; i++)
         {
             newStack[i] = this.stack[i];
         }

         this.stack = newStack;
      }
    }
}
