using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcLibrary
{
    public class PerformanceAnalyser : IDisposable
    {
        private long StartTime = -1;

        public PerformanceAnalyser()
        {
            StartTime = DateTime.Now.Ticks;
        }

        public void Dispose()
        {
            long endTime = DateTime.Now.Ticks;

            long difference = endTime - StartTime;

            double seconds = (double)difference / 10000.0 / 1000.0;

            System.Diagnostics.Debug.WriteLine("Excution Time: " + seconds);
        }
    }
}