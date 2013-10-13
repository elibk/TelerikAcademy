using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DividingFactorials
{
    static void Main()
    {
        Console.Write("Find result of N!/K! if 1<K<N.\nEnter K=");
        decimal K = decimal.Parse(Console.ReadLine());
        Console.Write("Enter N=");
        decimal N = decimal.Parse(Console.ReadLine());

        if (K > 1 && N > K)
        {
            for (decimal i = N - 1; i > K; i--)
            {
                N = N * i;
            }

            for ( decimal i = K-1; i >= 1 ; i--)
            {
                K = K * i;
            }

            N = N * K;

            Console.WriteLine("{0}/{1} = {2}",N,K,K/N);
        }
    }
}

