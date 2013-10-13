////
namespace H0102ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    public static class ExtensionsIEnumerable
    {
        public static T Min<T>(this IEnumerable<T> collection) // method Min exist in linq for list and array
              where T : IComparable
        {
            T min = GetFirstValue(collection);
           //// T sth = default(T);

            foreach (var item in collection)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) // method Max exist in linq for list and array
             where T : IComparable
        {
            T max = GetFirstValue(collection);
            ////T sth = default(T);

            foreach (var item in collection)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Sum<T>(this IEnumerable<T> collection) // method Sum exist in linq for list and array
        {
            ////T sum = GetFirstValue(collection);
            T sum = default(T);

            foreach (var item in collection)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        public static T Average<T>(this IEnumerable<T> collection) // method Average in linq exist for list and array
        {
            ////T sum = GetFirstValue(collection);
            T average = default(T);
            int count = 0;

            foreach (var item in collection)
            {
                average += (dynamic)item;
                count++;
            }

            return (dynamic)average / count;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            T product = GetFirstValue(collection);

            foreach (var item in collection)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static void PrintOnConsole<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static T GetFirstValue<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                return item;
            }

            throw new ArgumentException();
        }
    }
}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace IEnumerableExt
////{
////   static class IEnumerableExt
////    {
////       private static T Reduce<T>(this IEnumerable<T> items, Func<dynamic, T, T> function, dynamic first = null)
////       {
////           IEnumerator<T> i = items.GetEnumerator();
////           i.MoveNext();
////           T previous = first ?? i.Current;

////           while (i.MoveNext())
////           {
////               previous = function(i.Current, previous);

////           }
////           return previous;
////       }
////       //method for maximum element
////       static T Max<T>(this IEnumerable<T> items)
////       {
////           return items.Reduce((a, b) => a > b ? a : b);
////       }
////       //method for minimum element
////       static T Min<T>(this IEnumerable<T> items)
////       {
////           return items.Reduce((a, b) => a < b ? a : b);
////       }
////       //method for sum
////       static T Sum<T>(this IEnumerable<T> items)
////       {
////           return items.Reduce((a, b) => a + b);
////       }
////       //method for production
////       static T Product<T>(this IEnumerable<T> items)
////       {
////           return items.Reduce((a, b) => a * b);
////       }
////       //method for counting elements
////       static int Count<T>(this IEnumerable<T> items)
////       {
////           return Convert.ToInt32(items.Reduce((a, _) => a + 1, 1));
////       }
////       //method for average
////       static double Average<T>(this IEnumerable<T> items)
////       {
////           return Convert.ToDouble(items.Sum()) / Convert.ToDouble(items.Count());
////       }
       
       
////       static void Main()
////        {
            
////            double[] IEelements = new double[] { 18.5, 19.3, 0, 10,78, -96, 56.36};

////            Console.WriteLine("Max: {0}", IEelements.Max<double>());
////            Console.WriteLine("Min: {0}", IEelements.Min<double>());
////            Console.WriteLine("Sum: {0}", IEelements.Sum<double>());
////            Console.WriteLine("Product: {0}", IEelements.Product<double>());
////            Console.WriteLine("Count: {0}", IEelements.Count<double>());
////            Console.WriteLine("Average: {0}", IEelements.Average<double>()); 
////        }
////    }
////}
