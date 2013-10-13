using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithinCircleAndOutOfRectangle
{
    class PointWithinCircleAndOutOfRectangle
    {
        static void Main()
        {
            Console.WriteLine("Enter point's (x,  y) to check if it is within a circle the circle K((1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (((x-1)*(x-1)+(y-1)*(y-1)<=9))
            {

                if ((y<=1 && y>=-1)&&(x>1))
                {
                    Console.WriteLine("The point is within the circle and within the rectangle.");
                }
                else
                {
                    Console.WriteLine("The point is within circle and out of the the rectangle.");
                }
            }
            else
            {
                Console.WriteLine("The point is out of the circle.");
            }
        }
    }
}
