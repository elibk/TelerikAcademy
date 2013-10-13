////
namespace H0708TimerAndEvents
{
    using System;
    using System.Linq;

    public class ListenerMinutes
    {
        public void Subscribe(Clock clock)
        {
            clock.MinutePast += new Clock.MinuteHandler(PrintMessage);
        }

        private static void PrintMessage(Clock clock, EventArgs argMinute)
        {
            Console.WriteLine("You've just lost one minute. Maybe You Should Stop Staring And Start Learning !");
            Console.Beep();
        }
    }
}
