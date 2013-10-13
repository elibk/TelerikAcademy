using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H01KnapsackProblem
{
    public class Knapsack
    {
        public static IEnumerable<Product> Solve(int weight,
            List<Product> products)
        {
            List<Product> knapsack = new List<Product>();

            Tuple<int, List<int>>[,] matrix =
                new Tuple<int, List<int>>[products.Count + 1, weight + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = new Tuple<int, List<int>>(0, new List<int>());
                }
            }

            for (int productsCount = 1; productsCount < matrix.GetLength(0); productsCount++)
            {
                for (int currentWeight = 1; currentWeight < matrix.GetLength(1); currentWeight++)
                {
                    var previous = matrix[productsCount - 1, currentWeight];

                    if (currentWeight >= products[productsCount - 1].Weight)
                    {

                        var potencial = matrix[productsCount - 1,
                            currentWeight - products[productsCount -1].Weight];
                        if (previous.Item1 >= potencial.Item1 + products[productsCount- 1].Cost)
                        {
                            List<int> newList = new List<int>();
                            newList.AddRange(previous.Item2);
                            matrix[productsCount, currentWeight] = new Tuple<int, List<int>>(previous.Item1, newList);
                        }
                        else
                        {
                            List<int> newList = new List<int>();
                            newList.AddRange(potencial.Item2);
                            newList.Add(productsCount - 1);
                            matrix[productsCount, currentWeight] = new Tuple<int, List<int>>(potencial.Item1 + products[productsCount -1].Cost, newList);
                        }
                    }
                    else
                    {
                        List<int> newList = new List<int>();
                        newList.AddRange(previous.Item2);
                        matrix[productsCount, currentWeight] = new Tuple<int, List<int>>(previous.Item1, newList);

                    }
                }
            }

            int sum = matrix[products.Count, weight].Item1;

            var collection = matrix[products.Count, weight].Item2;

            foreach (var item in collection)
            {
                knapsack.Add(products[item]);
            }
            return knapsack;
        }

        public static int GetSum(int weight,
            List<Product> products)
        {
            

           int[,] matrix =
                new int[products.Count + 1, weight + 1];

            for (int productsCount = 1; productsCount < matrix.GetLength(0); productsCount++)
            {
                for (int currentWeight = 1; currentWeight < matrix.GetLength(1); currentWeight++)
                {
                    var previous = matrix[productsCount - 1, currentWeight];
                    if (currentWeight >= products[productsCount -1].Weight)
                    {
                       
                        var potencial = matrix[productsCount - 1, currentWeight - products[productsCount- 1].Weight];
                        matrix[productsCount, currentWeight]= Math.Max(previous, potencial + products[productsCount -1].Cost);
                    }
                    else
                    {
                        matrix[productsCount, currentWeight] = previous;

                    }
                }       
            }

            return matrix[products.Count, weight];
        }


        public static int GetMaximumValueOfLoad(int weight, List<Product> products)
        {
            int[][] optimalValues = new int[products.Count + 1][];

            for (int i = 0; i <= products.Count; i++)
            {
                //create an array to hold up to the vehicle capacity
                optimalValues[i] = new int[weight + 1];
            }

            for (int j = 1; j <= weight; j++)
            {
                for (int i = 1; i <= products.Count; i++)
                {
                    int currentWeight = products[i -1].Weight;
                    int currentValue = products[i -1].Cost;
                    int previousOptimalValue = optimalValues[i - 1][j];
                    int spaceLeft = j - currentWeight;

                    if (spaceLeft < 0)
                    {
                        //too heavy, use last value
                        optimalValues[i][j] = previousOptimalValue;
                    }
                    else
                    {
                        //there is space to fit this new value in.
                        //see if its better to keep the old one, or add the value of this one, to whatever the value of
                        // the one that fits into the left over space is.

                        int[] options = { previousOptimalValue, optimalValues[i - 1][spaceLeft] + currentValue };
                        optimalValues[i][j] = options.Max();
                    }
                }

            }

            return optimalValues[products.Count][weight];
        }
    }
}
