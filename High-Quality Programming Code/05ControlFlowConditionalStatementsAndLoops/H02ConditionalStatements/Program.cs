////
namespace H02ConditionalStatements
{
    using System;
    using System.Linq;

   internal class Program
    {
       private static void Main(string[] args)
        {
            Potato potato = new Potato();
            ////... 
            
            if (potato.IsReadyForCooking())
            { 
                Cook(potato); 
            }

            //////// second part

            double cordinateX = 5;
            double cordinateY = 5;

            if (AreCordinatesInRange(cordinateX, cordinateY) && IsTheCellVisitable(cordinateX, cordinateY))
            {
               VisitCell();
            }
        }

        private static bool AreCordinatesInRange(double cordinateX, double cordinateY)
        {
            const double MinValueForX = 0;
            const double MaxValueForX = 0;

            const double MinValueForY = 0;
            const double MaxValueForY = 0;

            bool checkForX = cordinateX >= MinValueForX && cordinateX <= MaxValueForX;
            bool checkForY = cordinateY >= MinValueForY && cordinateY <= MaxValueForY;

            return checkForX && checkForY;
        }

        private static bool IsTheCellVisitable(double cordinateX, double cordinateY)
        {
            throw new NotImplementedException();
        }

        private static void VisitCell()
        {
            throw new NotImplementedException();
        }

        private static void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}
