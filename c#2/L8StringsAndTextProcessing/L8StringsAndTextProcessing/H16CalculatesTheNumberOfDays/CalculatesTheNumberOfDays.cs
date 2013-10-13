using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H16CalculatesTheNumberOfDays
{
    class CalculatesTheNumberOfDays
    {
        static void Main(string[] args)
        {
            string firstDate = "10.12.2004";
           
            string secondDate = "10.12.2005";

            Console.WriteLine(CountDays(firstDate, secondDate)); 
        }

        private static int CountDays(string firstDate, string secondDate)
        {

            DateTime fd = DateTime.Parse(firstDate);
            DateTime sd = DateTime.Parse(secondDate);
            int count = new int();

            if (fd < sd)
            {
                while (fd != sd)
                {
                    fd = fd.AddDays(1);
                    count++;
                }
            }
            else
            {
                while (fd != sd)
                {
                    sd = sd.AddDays(1);
                    count++;
                }
            }

            return count;
        }
    }
}
