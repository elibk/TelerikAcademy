using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4UKFlag
{
    class UKFlag
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            string
                outsideDots = new string('.', 0),
                insideDots = new string('.', 0),
                middle = new string('-', (N / 2 - 1)+1);

            for (int outsideDotsLen = 0, insideDotsLen = N/2-1; insideDotsLen >= 0; outsideDotsLen++,insideDotsLen--)
            {
                outsideDots = new string('.', outsideDotsLen);
                insideDots = new string('.', insideDotsLen);
                Console.WriteLine(outsideDots + "\\" + insideDots + "|" + insideDots + "/"+ outsideDots);
            }
            Console.WriteLine(middle + '*' + middle);

            for (int outsideDotsLen = N / 2-1, insideDotsLen = 0; outsideDotsLen >= 0; outsideDotsLen--, insideDotsLen++)
            {
                outsideDots = new string('.', outsideDotsLen);
                insideDots = new string('.', insideDotsLen);
                Console.WriteLine(outsideDots + "/" + insideDots + "|" + insideDots + "\\" + outsideDots);
            }
        }
    }
}
