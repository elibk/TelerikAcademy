using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class NotPrimeNumberException : Exception
    {
        public NotPrimeNumberException(int number)
            : base(string.Format("{0} is not prime.", number))
        { 
        }
    }
