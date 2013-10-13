////
namespace H0708TimerAndEvents
{
    using System;
    using System.Linq;

   public class ListenerSeconds
    {
       public void Subscribe(Clock clock)
        {
            clock.SecondPast += new Clock.SecondHandler(PrintMessage);
        }

       private static void PrintMessage(Clock clock, EventArgs argSecond)
        {
            Console.WriteLine("Another second past!");
        }
    }
}
