////
namespace H0708TimerAndEvents
{
    using System;
    using System.Linq;

   public class TestTimerAndEvents
    {
       private static void Main(string[] args)
        {
            Timer timer = new Timer();
            Lottary lottary = new Lottary(timer.Run);
            lottary(1, 5);

            Clock clock = new Clock();
            ListenerSeconds listenerSeconds = new ListenerSeconds();
            ListenerMinutes listenerMinutes = new ListenerMinutes();
            listenerSeconds.Subscribe(clock);
            listenerMinutes.Subscribe(clock);
            clock.Start();
        }
    }
}
