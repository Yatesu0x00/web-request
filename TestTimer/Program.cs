using System;
using System.Timers;

namespace TestTimer
{
    class Program
    {
        static int seconds = 0;
        public static void Main()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            Console.WriteLine("Press \'q\' to quit the sample.");
            if (Console.Read() == 'q')
            {

                Console.WriteLine("du opfer"); 
            };
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("test");
            seconds++;
        }
    }
}
