////
namespace JustBitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BitArray64 : IEnumerable<int>
    {
        #region Fields
        private static readonly ulong one = 1;
        private ulong array;
        #endregion

        #region Constructor

        public BitArray64(ulong array)
        {
            this.Array = array;
        }
        
        #endregion
        
        #region Properties
        
        public ulong Array
        {
            get
            {
                return this.array;
            }

            set
            {
                this.array = value;
            }
        }

        #endregion

        #region Indexer

        public int this[int position]
        {
            get
            {
                if (position >= 0 && position < 64)
                {
                    ulong nAndMask = this.Array & (one << position);
                    ulong bit = nAndMask >> position;
                    return (int)bit;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (position >= 0 && position < 64)
                {
                    if (value == 1)
                    {
                        ulong mask = one << position;
                        this.Array = this.Array | mask;
                    }

                    if (value == 0)
                    {
                        ulong mask = ~(one << position);
                        this.Array = this.Array & mask;
                    }
                    else
                    {
                        throw new ArgumentException("Value for bits should be 1 or 0");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(BitArray64 firstBitArray64, BitArray64 secondBitArray64)
        {
            if (firstBitArray64.Array == secondBitArray64.Array)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(BitArray64 firstBitArray64, BitArray64 secondBitArray64)
        {
            if (firstBitArray64 == secondBitArray64)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Enumerator
            
        public IEnumerator<int> GetEnumerator()
        {
            for (int p = 63; p >= 0; p--)
            {
                ulong nAndMask = this.Array & (one << p);  
                ulong bit = nAndMask >> p;
                yield return (int)bit;
            }
        }
            
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Override_official_Methods          
        public override bool Equals(object obj)
        {
            if (this.Array == (obj as BitArray64).Array)
            {
                return true;
            }
        
            return false;
        }
        
        public override int GetHashCode()
        {
            return this.Array.GetHashCode();
        }
        #endregion          
    }
}
