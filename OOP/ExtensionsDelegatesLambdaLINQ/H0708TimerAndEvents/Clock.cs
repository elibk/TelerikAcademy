////
namespace H0708TimerAndEvents
{
    using System;
    using System.Linq;

   public class Clock
    {
        private readonly EventArgs argMinute = null;
        private readonly EventArgs argSecond = null;
        private DateTime clock = DateTime.Now;
        private int countSeconds = 0;
       
        public delegate void MinuteHandler(Clock clock, EventArgs argMinute);

        public delegate void SecondHandler(Clock clock, EventArgs argSecond);

        public event MinuteHandler MinutePast;

        public event SecondHandler SecondPast;
        
        public void Start()
        {
            Console.WriteLine("Press ESC to stop.");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo presedKey = Console.ReadKey();
                    if (presedKey.Key.CompareTo(ConsoleKey.Escape) == 0)
                    {
                        break;
                    }                 
                }

                if (this.countSeconds == 60)
                {
                    this.MinutePast(this, this.argMinute);
                    this.countSeconds = 0;
                }

                if (DateTime.Now.Second == this.clock.AddSeconds(1).Second)
                {
                    this.clock = this.clock.AddSeconds(1);
                    this.SecondPast(this, this.argSecond);
                    this.countSeconds++;
                }
            }
        }
    }
}
