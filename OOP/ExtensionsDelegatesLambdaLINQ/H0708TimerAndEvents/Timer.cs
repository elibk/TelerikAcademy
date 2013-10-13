////
namespace H0708TimerAndEvents
{
    using System;
    using System.Linq;
    using System.Timers;

    public delegate void Lottary(uint loseIntervalSeconds, uint winIntervalSeconds);

    public class Timer
     {
       private static System.Timers.Timer aTimerWin;
       private static System.Timers.Timer aTimerLose;

        public void Run(uint loseTimer, uint winTimer)
        {
            aTimerLose = new System.Timers.Timer(loseTimer * 1000);
            aTimerWin = new System.Timers.Timer(winTimer * 1000);
            aTimerWin.Elapsed += new ElapsedEventHandler(Win);
            aTimerWin.Enabled = true;

            aTimerLose.Elapsed += new ElapsedEventHandler(Lose);
            aTimerLose.Enabled = true;

            Console.WriteLine("Press Enter to stop.");
            Console.ReadLine();
            aTimerLose.Dispose();
            aTimerWin.Dispose();
        }

        private static void Lose(object source, ElapsedEventArgs agument)
        {
            Console.WriteLine("Try again!");
        }

        private static void Win(object source, ElapsedEventArgs agument)
        {
            Console.WriteLine("You win a prize!");
        }
    }
}
