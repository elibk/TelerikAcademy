using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    class SalariesCalculator
    {
        private static int n;
        private static bool[,] matrix;
        private static long[] visited;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            matrix = new bool[n, n];
            visited = new long[n];

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    if (line[i] == 'Y')
                    {
                        matrix[row, i] = true;
                    }
                }
            }

            Console.WriteLine(Dfs());
        }

        private static long Dfs()
        {
            long salaries = 0;

            for (long i = 0; i < n; i++)
            {
                salaries += Move(i);
            }
            return salaries;
        }

        private static long Move(long currentEmployeee)
        {

            if (visited[currentEmployeee] > 0)
            {
                return visited[currentEmployeee];
            }

            long salary = 0;

            for (int connectionToOtherEdge = 0; connectionToOtherEdge < matrix.GetLength(0); connectionToOtherEdge++)
            {
                if (matrix[currentEmployeee, connectionToOtherEdge])
                {
                    salary += Move(connectionToOtherEdge);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }
            visited[currentEmployeee] = salary;
            return salary;
        }
    }
}
