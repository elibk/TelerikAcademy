using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNumbersAndPrintsTheirSum
{
    class GetNumbersAndPrintsTheirSum
    {
        static void Main(string[] args)
        
        {

            while (true)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                int sum = sum + num;
                Console.WriteLine( "The sum of the entered numbers now is:{0}.",sum);
            }
        }
    }
}
