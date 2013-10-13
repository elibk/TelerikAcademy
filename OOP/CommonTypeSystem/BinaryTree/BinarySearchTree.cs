using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public struct BinarySearchTree<T> : IEnumerable<int> 
        where T : struct
    {
        private T numArray;
        private int lenght;
        private static dynamic one = 1;


        public BinarySearchTree(T numArray)
            :this()
        {
            this.NumArray = numArray;
            lenght = GetLenght();
        }

        private int GetLenght()
        {
            
             return ConvertSignNumToBinary(this.NumArray).Length;
          
        }

        public T NumArray
        {
            get
            {
                return this.numArray;
            }
            set
            {
                this.numArray = value;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int p = 63; p >= 0; p--)
            {
                T nAndMask = this.NumArray & ((dynamic)one << p);
                dynamic bit = (dynamic)nAndMask >> p;
                yield return (int)bit;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static string ConvertUnSignNumToBinary(T number)
        {

            List<int> bits = new List<int>();
            bool positiveCheck = true;

            if ((dynamic)number < 0)
            {
                positiveCheck = false;
                number = (T)(((dynamic)number * -1) - 1);
            }

            while ((dynamic)number != 0)
            {
                if (positiveCheck)
                {
                    bits.Add((Math.Abs((dynamic)number % 2)));
                }


                number = ((dynamic)number / 2);
            }
            StringBuilder reversedBits = new StringBuilder();

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                reversedBits.Append(bits[i]);
            }
            return reversedBits.ToString().PadLeft(64, '0');
        }

        private static string ConvertSignNumToBinary(T number)
        {

            List<int> bits = new List<int>();
            bool positiveCheck = true;

            if ((dynamic)number < 0)
            {
                positiveCheck = false;
                number = (T)(((dynamic)number * -1) - 1);
            }

            while ((dynamic)number != 0)
            {
                if (positiveCheck)
                {
                    bits.Add((Math.Abs((dynamic)number % 2)));
                }
                

                number = ((dynamic)number / 2);
            }
            StringBuilder reversedBits = new StringBuilder();

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                reversedBits.Append(bits[i]);
            }
            return reversedBits.ToString().PadLeft(64, '0');
        }
    }
}
