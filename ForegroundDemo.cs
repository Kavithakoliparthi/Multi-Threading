using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThreading
{
    /// <summary>
    /// create a ForegroundDemo class
    /// </summary>
    class ForegroundDemo
    {
        /// <summary>
        /// craete main method
        /// it is the starting point of the program
        /// </summary>
        static void Main()
        {
            Process();
            Console.ReadLine();
        }
        /// <summary>
        /// craete Process()
        /// </summary>
        public static void Process()
        {
            BackgroundTest shortTest = new BackgroundTest(5);
            Thread foregroundThread = new Thread(new ThreadStart(shortTest.RunLoop));

            BackgroundTest longTest = new BackgroundTest(10);
            Thread backgroundThread = new Thread(new ThreadStart(longTest.RunLoop));
            backgroundThread.IsBackground = true;
                //IsBackground is a method. get (or) sets value indicating whether (or) not thread is a background thread
            foregroundThread.Start();
            backgroundThread.Start();
        }
    }
    /// <summary>
    /// craeting BackgroundTest class
    /// </summary>
    class BackgroundTest
    {
        /// <summary>
        /// creating a log
        /// </summary>
        static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int maxIterations;
        /// <summary>
        /// creating a parameterized constructor
        /// </summary>
        /// <param name="maxIterations"></param>
        public BackgroundTest(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }
        /// <summary>
        /// creating RunLoop method
        /// </summary>
        public void RunLoop()
        {
            for (int i = 0; i < maxIterations; i++)
            {
                log.InfoFormat("{0} count: {1}",Thread.CurrentThread.IsBackground ?"Background Thread" : "Foreground Thread", i);
                Thread.Sleep(250);
            }
            log.InfoFormat("{0} finished counting.",Thread.CurrentThread.IsBackground ?"Background Thread" : "Foreground Thread");
        }
    }
}
