using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomsBlog.Utils
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

            //System.Diagnostics.Debug.WriteLine("Excution Time: " + seconds);

            HttpContext context = HttpContext.Current;
            //context.Response.Write("<script> alert('Execution Time was " + seconds + " seconds.'); </script>");
        }
    }
}