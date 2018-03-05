using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    /// <summary>
    /// Crete a class
    /// </summary>
    class ThreadDemo7
    {
     
        public long count1, count2;
        /// <summary>
        /// Creating IncrementCount1 method
        /// </summary>
        public void IncrementCount1()
        {
            while (true)
                count1 += 1;
        }
        /// <summary>
        /// Creating IncrementCount2 method
        /// </summary>
        public void IncrementCount2()
        {
            while (true)
                count2 += 1;
        }
    }
    class ThreadPriorities
    {
        /// <summary>
        /// Creating a main method
        /// In that provide the priorities for the thread
        /// call Abort() and Join()
        /// </summary>
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            ThreadDemo7 obj = new ThreadDemo7();
            Thread t1 = new Thread(obj.IncrementCount1);
            Thread t2 = new Thread(obj.IncrementCount2);
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();
            Log.Info("Main thread going to sleep");
            Thread.Sleep(4000);
            Log.Info("Main thread wokeup");
            
            t1.Abort();
            t2.Abort();
            t1.Join();
            t2.Join();

            Log.Info("Count1:" +obj.count1);
            Log.Info("Count2:" + obj.count2);
        }
    }
}
