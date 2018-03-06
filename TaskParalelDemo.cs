using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
namespace MultiThreading
{
    /// <summary>
    /// Class for Parallel foreach loop.
    /// </summary>
    public class TaskParalelDemo
    {
        /// <summary>
        /// creating a log
        /// </summary>
         private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// create ParallelForeach()
        /// </summary>
        public static void ParallelForEach()
        {
            string[] colors = { "1. Red", "2.Green", "3.Blue", "4.Yellow" };
            log.Info("Using Parallel Foreach loop");
            Stopwatch s = Stopwatch.StartNew();
            Parallel.ForEach(colors, color =>
            {
                log.InfoFormat("{0}, Thread Id={1}", color, Thread.CurrentThread.ManagedThreadId);
                    //ManagedThreadId gets the unique identifier for the current thread
                Thread.Sleep(100);
            });
            log.InfoFormat("Parallel.ForEach() execution time={0} seconds", s.Elapsed.TotalSeconds);
            log.Info("Using Traditional forEach Loop");
            Stopwatch s1 = Stopwatch.StartNew();
            foreach (string color in colors)
            {
                log.InfoFormat("{0}, Thread Id={1}", color, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(200);
            }
            log.InfoFormat("foreach loop execution time ={0} seconds\n", s1.Elapsed.TotalSeconds);
        }
        /// <summary>
        /// main 
        /// </summary>
        /// <param name="args"></param>
      static void Main(string[] args)
      {
            ParallelForEach();
             Console.Read();
      }
   }
}

