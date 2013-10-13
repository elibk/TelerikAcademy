using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNumbersPrintsTheirSum
{
    class GetNumbersPrintsTheirSum
    {
        static void Main(string[] args)
        {
            int num = 0;
            int sum = 0;

            while (true)
            {
                Console.Write("Enter integer number:");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
                Console.WriteLine("The sum of the entered numbers now is:{0}.", sum);
            }
        }
    }
}