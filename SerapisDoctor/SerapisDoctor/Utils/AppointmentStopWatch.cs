using System;
using System.Diagnostics;

namespace SerapisDoctor.Utils
{
    public static class AppointmentStopWatch
    {
        static Stopwatch stopWatch = new Stopwatch();

        //Start the count and just count
        public static void StartClockCount()
        {
            //Check first if it's running
            if (!stopWatch.IsRunning)
            {
                stopWatch.Start();
            }
        }

        public static void StopClockCount()
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
            }
        }

        
        public static TimeSpan GetDuration()
        {
            return stopWatch.Elapsed;
        }

        //Use when the Stop watch class does not work or is not inaccurate
        public static int GetDuration(DateTime startTime, DateTime nowTime)
        {
            return nowTime.Hour - startTime.Hour;
        }
    }
}
