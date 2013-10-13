using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPopGame.Common
{
   public class InvalidMoveException : Exception
    {
       public InvalidMoveException()
           : base("Invalid move. There is no balloon at that place.")
       {

       }
       public InvalidMoveException(string message)
       :base(message)
       {
       }
    }
}
