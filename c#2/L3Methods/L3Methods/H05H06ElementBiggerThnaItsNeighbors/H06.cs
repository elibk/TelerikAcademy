////
namespace H05H06ElementBiggerThnaItsNeighbors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

     public class H06
    {
        public int GetFirstBiggerIndex(List<int> biggerElementsindexes)
        {
            if (biggerElementsindexes.Count == 0)
            {
                return -1;
            }
            else
            {
                return biggerElementsindexes[0];
            }
        }
    }
}
