////
namespace JustBitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Test
    {
        private static void Main(string[] args)
        {
            BitArray64 array = new BitArray64(ulong.MaxValue);

            Console.WriteLine(array[2]);

            Console.WriteLine();
            //// Binary Representation for check
            Console.WriteLine(ConvertToBinary(array.Array)); // with numeral system
            Console.WriteLine(Convert.ToString((long)array.Array, 2)); // with c# integrate method
            ////You can call it unsigned or signed, but its the same if you look at it bitwise!
            ////So if you do this:
            ////Convert.ToString((long)myNumber,2);
            ////you would get the same bits as you would if there were ulong implementation of Convert.ToString(), and thats why there is none... ;)
            ////Therefore, ((long)-1) and ((ulong)-1) looks the same in memory. // http://stackoverflow.com/questions/6985965/is-there-a-c-sharp-function-that-formats-a-64bit-unsigned-value-to-its-equival
            Console.WriteLine(new string('-', Console.WindowWidth));
            if (array[0] == 1)
            {
                array[0] = 0;
            }
            else
            {
                array[0] = 1;
            }

            foreach (var bit in array)
            {
                Console.Write(bit);
            }

            Console.WriteLine();
        }

        private static string ConvertToBinary(ulong number)
        {
            List<int> bits = new List<int>();

            while (number != 0)
            {
                bits.Add(Math.Abs((int)number % 2));

                number = number / 2;
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
