using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace H01KnapsackProblem.Test
{
    [TestClass]
    public class KnapsackTest
    {
        [TestMethod]
        public void Solve_Example()
        {
            int weight = 9;
            

            List<Product> products = new List<Product>
                {
                    new Product("beer",3,2),
                    new Product("vodka",8,12),
                    new Product("cheese",4,5),
                    new Product("nuts",1,4),
                    new Product("ham",2,3),
                    new Product("whiskey",8,13),
                };

          
            var actual = Knapsack.Solve(weight,products);

            
            StringBuilder result = new StringBuilder();
            foreach (var item in actual)
            {
                result.Append(item.Name);
                result.Append('+');
            }

           result.Length--;

            string expected = "nuts+whiskey";

            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        public void Solve_ExampleWeight22()
        {
            int weight = 22;


            List<Product> products = new List<Product>
                {
                    new Product("beer",3,2),
                    new Product("vodka",8,12),
                    new Product("cheese",4,5),
                    new Product("nuts",1,4),
                    new Product("ham",2,3),
                    new Product("whiskey",8,13),
                };


            var actual = Knapsack.Solve(weight, products);


            StringBuilder result = new StringBuilder();
            foreach (var item in actual)
            {
                result.Append(item.Name);
                result.Append('+');
            }

            result.Length--;

            string expected = "vodka+cheese+nuts+whiskey";

            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        public void Solve_ExampleWeight25()
        {
            int weight = 16;


            List<Product> products = new List<Product>
                {
                    new Product("beer",3,2),
                    new Product("vodka",8,12),
                    new Product("cheese",4,5),
                    new Product("nuts",1,4),
                    new Product("ham",2,3),
                    new Product("whiskey",8,13),
                };


            var actual = Knapsack.Solve(weight, products);


            StringBuilder result = new StringBuilder();
            foreach (var item in actual)
            {
                result.Append(item.Name);
                result.Append('+');
            }

            result.Length--;

            string expected = "vodka+whiskey";

            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        public void Solve_ExampleWeight18Sum()
        {
            int weight = 22;


            List<Product> products = new List<Product>
                {
                    new Product("beer",3,2),
                    new Product("vodka",8,12),
                    new Product("cheese",4,5),
                    new Product("nuts",1,4),
                    new Product("ham",2,3),
                    new Product("whiskey",8,13),
                };


            var actual = Knapsack.GetSum(weight, products);
            //var actual = Knapsack.GetMaximumValueOfLoad(weight, products);
            
            Assert.AreEqual(34, actual);
        }


        [TestMethod]
        public void Solve_Example500()
        {
            int weight = 9;


            List<Product> products = new List<Product>
                {
                    new Product("beer",3,2),
                    new Product("vodka",8,12),
                    new Product("cheese",4,5),
                    new Product("nuts",1,4),
                    new Product("ham",2,3),
                    new Product("whiskey",8,13),
                };


            var actual = Knapsack.Solve(weight, products);


            StringBuilder result = new StringBuilder();
            foreach (var item in actual)
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        products.Add(new Product(products[j].Name + products.Count, products[j].Weight, products[j].Cost));
                    }
                }

                result.Append(item.Name);
                result.Append('+');
            }

            result.Length--;

            string expected = "nuts+whiskey";

            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        public void Solve_ExampleSumValue()
        {
            int weight = 9;


            List<Product> products = new List<Product>
                {
                    new Product("beer",3,2),
                    new Product("vodka",8,12),
                    new Product("cheese",4,5),
                    new Product("nuts",1,4),
                    new Product("ham",2,3),
                    new Product("whiskey",8,13),
                };


           
            var actual = Knapsack.GetSum(weight,products);
            Assert.AreEqual(17, actual);
        }
    }
}
