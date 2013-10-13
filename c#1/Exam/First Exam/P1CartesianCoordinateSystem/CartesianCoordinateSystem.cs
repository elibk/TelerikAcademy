using System;
//Find poit in Cartesian Coordinate System
class CartesianCoordinateSystem
{
    static void Main()
    {
        decimal X = decimal.Parse(Console.ReadLine());
        decimal Y = decimal.Parse(Console.ReadLine());

        if (X > 0)
        {
            if (Y > 0)
            {
                Console.WriteLine(1);
            }
            else if (Y < 0)
            {
                Console.WriteLine(4);
            }
            else // Y == 0
            {
                Console.WriteLine(6);
            }
        }
        else if(X < 0)
        {
            if (Y > 0)
            {
                Console.WriteLine(2);
            }
            else if (Y < 0)
            {
                Console.WriteLine(3);
            }
            else // Y == 0
            {
                Console.WriteLine(6);
            }
        }
        else // X == 0
        {
            if (Y != 0)
            {
                Console.WriteLine(5);
            }
            else 
            {
                Console.WriteLine(0);
            }
        }
    }
}

