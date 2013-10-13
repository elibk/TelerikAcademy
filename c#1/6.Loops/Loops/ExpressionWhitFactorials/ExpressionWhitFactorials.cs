using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExpressionWhitFactorials
{
    static void Main()
    {
        Console.Write("Find result of N!*K! / (K-N)! if 1<N<K.\nEnter N=");
        decimal N = decimal.Parse(Console.ReadLine());
        Console.Write("Enter K=");
        decimal K = decimal.Parse(Console.ReadLine());
        decimal difference = K - N;

        if (N > 1 && K > N)
        {
            if (N < difference)
            {
                for (decimal i = K - 1; i > difference; i--)
                {
                    K = K * i;
                }

                for (decimal i = difference - 1; i >= 1; i--)
                {
                    difference = difference * i;
                }

                for (decimal i = N - 1; i >= 1; i--)
                {
                    N = N * i;
                }

                difference = difference * N;
                K = K * difference;

            }
            else if (N > difference)
            {
                for (decimal i = K - 1; i > N; i--)
                {
                    K = K * i;
                }

                for (decimal i = N - 1; i > difference; i--)
                {
                    N = N * i;
                }

                for (decimal i = difference - 1; i >= 1; i--)
                {
                    difference = difference * i;
                }

                N = N * difference;
                K = K * N;
            }
            else // (K == difference)
            {
                for (decimal i = K - 1; i > N; i--)
                {
                    K = K * i;
                }

                for (decimal i = N - 1; i >= 1; i--)
                {
                    N = N * i;
                }

                K = K * N;
                difference = N;
            }

            Console.WriteLine("{0}*{1}/{2} = {3}",N,K,difference, (N*K)/difference);
        }
    }
}
