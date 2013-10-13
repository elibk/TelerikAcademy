////
namespace JustException
{
    using System;
    using System.Linq;

    public class InvalidRangeException<T> : Exception
        where T : IComparable
    {
        private T start;
        private T end;
      
        public InvalidRangeException(T start, T end)
            : this(start, end, string.Format("Out of range [{0}...{1}]", start, end))
        {
        }

        public InvalidRangeException(T start, T end, string message)
            : base(message)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start
        {
            get
            {
                return this.start;
            }

            set
            {
                this.start = value;
            }
        }

        public T End
        {
            get
            {
                return this.end;
            }

            set
            {
                if (value.CompareTo(this.Start) < 0)
                {
                    throw new ArgumentOutOfRangeException("Value for End must be greater than value for Start");
                }

                this.end = value;
            }
        }
    }
}
