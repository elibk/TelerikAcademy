////
namespace JustException
{
    using System;
    using System.Linq;

    public class Test
    {
        private static void Main(string[] args)
        {
            int number = 89;
            CheckNumber(number);
           // DateTime date = new DateTime(1979, 12, 12); // This will cause Exception
           // CheckDate(date);
        }

        private static void CheckDate(DateTime date)
        {
            DateTime start = new DateTime(1980, 1, 1),
            end = new DateTime(2013, 12, 31);

            if (date < start || date > end)
            {
                throw new InvalidRangeException<DateTime>(start, end);
            }
        }

        private static void CheckNumber(int number)
        {
            int start = 0,
            end = 100;

            if (number < start || number > end)
            {
                throw new InvalidRangeException<int>(start, end, "OUT OF RANGE");
            }
        }
    }
}
