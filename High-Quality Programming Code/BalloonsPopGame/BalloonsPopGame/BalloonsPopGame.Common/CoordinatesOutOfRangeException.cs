using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPopGame.Common
{
   public class CoordinatesOutOfRangeException : Exception
    {
       public CoordinatesOutOfRangeException()
           : base("The coordinates can not be out of the game field.")
       {
       }
       public CoordinatesOutOfRangeException(string message)
       :base(message)
       {
       }
    }
}
