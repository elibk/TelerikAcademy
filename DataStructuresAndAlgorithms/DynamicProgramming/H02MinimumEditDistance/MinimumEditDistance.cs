using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02MinimumEditDistance
{
    public class MinimumEditDistance
    {
        public static double Solve(string startState, string endState)
        {
            double[,] distances = new double[startState.Length + 1, endState.Length + 1];
            for (int i = 0; i <= startState.Length; i++)
            {
                distances[i, 0] = i * 0.9;
            }
            for (int j = 0; j <= endState.Length; j++)
            {
                distances[0, j] = j * 0.8;
            }
            for (int j = 1; j <= endState.Length; j++)
            {
                for (int i = 1; i <= startState.Length; i++)
                {
                    if (startState[i - 1] == endState[j - 1])
                    {
                        distances[i, j] = distances[i - 1, j - 1];  //no operation
                    }
                    else
                    {
                        double value = Math.Min(Math.Min(
                            distances[i - 1, j] + 0.9,    //a deletion
                            distances[i, j - 1] + 0.8),   //an insertion
                            distances[i - 1, j - 1] + 1 //a substitution
                            );

                        distances[i, j] = value;


                    }
                }
            }
            return distances[startState.Length, endState.Length];
        }
    }
}
