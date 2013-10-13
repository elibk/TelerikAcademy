using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02ColorfulBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> values = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            int result = 0; 
            for (int i = 0; i < n; i++)
            {
                int currentValue = int.Parse(Console.ReadLine());
                if (!values.ContainsKey(currentValue))
                {
                    values.Add(currentValue, 0);
                }
                
                values[currentValue]++;

                if (currentValue + 1 == values[currentValue])
                {
                    values.Remove(currentValue);
                    result += currentValue + 1;
                }
                

            }

            foreach (var item in values)
            {
                result += item.Key + 1;
            }

            Console.WriteLine(result);
        }
    }
}
