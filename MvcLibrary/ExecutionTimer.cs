using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcLibrary
{
    public class ExecutionTimer
    {
        private const string CONTEXT_KEY = "__MvcLibrary.ExecutionTimer.CONTEXT_KEY";

        private ExecutionTimer() { }

        private long StartTimeTicks = 0;

        public static void StartTimer()
        {
            ExecutionTimer timer = new ExecutionTimer();
            timer.StartTimeTicks = DateTime.Now.Ticks;

            HttpContext context = HttpContext.Current;

            if (context.Items[CONTEXT_KEY] == null)
            {
                context.Items.Add(CONTEXT_KEY, timer);
            }
        }

        public static decimal GetExecutionTimeSoFar()
        {
            HttpContext context = HttpContext.Current;

            if (context.Items[CONTEXT_KEY] != null)
            {
                ExecutionTimer timer = (ExecutionTimer)context.Items[CONTEXT_KEY];

                long endTimeTicks = DateTime.Now.Ticks;
                long difference = endTimeTicks - timer.StartTimeTicks;

                return ((decimal)difference / 10000m) / 1000m;
            }
            else
            {
                string message = "ExecutionTimer.StartTimer() needs to be called first before calling this method";
                throw new InvalidOperationException(message);
            }
        }
    }
}