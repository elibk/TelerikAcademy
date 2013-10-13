using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRandomBitsOfUint
{
    class ExchangeRandomBits
    {
        static void Main(string[] args)
      {

            Console.WriteLine(
                "This program will exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.");
            Console.Write("Enter unsign integer:");
            uint num = uint.Parse(Console.ReadLine());
            Console.WriteLine("This is bitwise expresion of {0} : {1}",num, Convert.ToString(num, 2).PadLeft(32, '0'));
            Console.Write("k=");
            int k = int.Parse(Console.ReadLine());
            Console.Write("p=");
            int p = int.Parse(Console.ReadLine());
            Console.Write("q=");
            int q = int.Parse(Console.ReadLine());


            uint[] firstArrey = new uint [32];
            uint[] secondArrey = new uint [32];

            if (p > q && p >= 0 && q > 0 && k > 0 && k+q<=32)
            {
                for (int i = p; i <= (p + k - 1); i++)
                {
                    int mask = 1 << i;
                    uint nAndMask = (uint)(num & mask);
                    firstArrey[i] = nAndMask >> i;
                    num = (uint)(num & ~(1 << i));
                }
                for (int i = q; i <= q + k - 1; i++)
                {
                    int mask = 1 << i;
                    uint nAndMask = (uint)(num & mask);
                    secondArrey[i] = nAndMask >> i;
                    num = (uint)(num & ~(1 << i));
                }


                for (int i = p, m = q; i <= p + k - 1; i++)
                {
                    uint mask = secondArrey[m] << i;
                    num = mask | num;
                }

                for (int i = q, m = p; i <= q + k - 1; i++)
                {
                    uint mask = firstArrey[m] << i;
                    num = mask | num;
                }

                Console.WriteLine(
                    "After we exchanges bits {0},{1} to {2} with bits {3},{4} to {5} "
                    , p, p + 1, p + k - 1, q, q + 1, q + k - 1);
                Console.WriteLine(
                    "the number now is {0} and this is its bitwise expresion {1}"
                    , num, Convert.ToString(num, 2).PadLeft(32, '0'));
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
