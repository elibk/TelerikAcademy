using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookApplication.Test
{
   internal static class AssistiveMethods
    {
       internal static bool AreEqual(Contact[] first, Contact[] second)
       {
           if (first.Length != second.Length)
           {
               return false;
           }

           for (int i = 0; i < first.Length; i++)
           {
               if (first[i].CompareTo(second[i]) != 0)
               {
                   return false;
               }
           }

           return true;
       }
    }
}
