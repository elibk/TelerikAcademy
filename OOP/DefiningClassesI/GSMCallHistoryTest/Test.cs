////
namespace GSMCallHistoryTest
{
    using System;
   
    using System.Linq;
    using JustGSM.AllFunctions;
    using System.Globalization;

   public class Test
    {
       private static void Main(string[] args) 
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GSM phone = new GSM("Galaxy", "Samsung", "Ivan Ivanov");

            FillPhoneHistory(phone);

            Console.WriteLine("Happy Holidays Mr {0}! This is your bill for December:", phone.Owner);
            PrintHistory(phone);
            decimal totalTax = phone.CalculateTax();
            Console.WriteLine(string.Format(new CultureInfo("es-ES"), "Tax per minute:{0:C}", Call.TaxPerMinute));
            Console.WriteLine(string.Format(new CultureInfo("es-ES"), "Your full charge is {0:C}.", totalTax));
            RemoveLongestCall(phone);
            totalTax = phone.CalculateTax();
            Console.WriteLine("Now the good news! Because you're very important to us WE will GIVE YOU your longest call for FREE!!!");
            Console.WriteLine(string.Format(new CultureInfo("es-ES"), "You own ONLY {0:C}.", totalTax));
           
            phone.ClearHistory();
            PrintHistory(phone);
        }

        private static void RemoveLongestCall(GSM phone)
        {
            uint? longestCall = phone.CallHistory[0].Duration;
            int longestCallIndex = 0;
            for (int i = 1; i < phone.CallHistory.Count; i++)
            {
                if (phone.CallHistory[i].Duration > longestCall)
                {
                    longestCall = phone.CallHistory[i].Duration;
                    longestCallIndex = i;
                }
            }

            phone.RemoveCall(phone.CallHistory[longestCallIndex]);
        }

        private static void FillPhoneHistory(GSM phone)
        {
            Random randomGenerator = new Random();

            for (int count = 0; count < 20; count++)
            {
                int date = randomGenerator.Next(1, 32);
                int hours = randomGenerator.Next(0, 24);
                int minutes = randomGenerator.Next(0, 60);
                int seconds = randomGenerator.Next(0, 60);
                int lastDigit = randomGenerator.Next(1, 10);
                int duration = randomGenerator.Next(1, 1000);
                Call some = new Call(new DateTime(2012, 12, date, hours, minutes, seconds), "0888 88 88 8" + lastDigit, (uint)duration);
                phone.AddCall(some);              
            }            
        }

        private static void PrintHistory(GSM phone)
        {
            for (int i = 0; i < phone.CallHistory.Count; i++)
            {
                Console.WriteLine(phone.CallHistory[i].ToString()); 
            }
        }

       
    }
}
