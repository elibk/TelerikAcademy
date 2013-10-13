using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointWithinCircle
{
    class PointWithinCircle 
    {
        static void Main()
        {
            Console.WriteLine("Enter point's (x,  y) to check if it is within a circle K(O, 5):");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (x*x + y*y < 25)
            {
                Console.WriteLine("The point whith cordinates {0} and {1} is within the circle.",x,y);
            }
            else
            {
                Console.WriteLine("The point whith cordinates {0} and {1} is not within the circle.",x,y);
                if (x*x + y*y == 25)
                {
                    Console.WriteLine("The ecxact point's place is on the border of the circle");
                }
            }
        }
    }
}
