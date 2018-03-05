using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    /// <summary>
    ///Creating aThreadTest class with default method
    /// </summary>
    class ThreadDemoo
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// create a default Test1()
        /// </summary>
        public void Test1()
        {
            for(int i=1;i<30;i++)
            {
                Log.Info("Thread1 Started");
                Log.Info("Test1:" + i);
                Log.Info("Thread1 Exiting");
            }

        }
        /// <summary>
        /// create Test2()
        /// in the method Thread go to sleep for 10 seconds.
        /// </summary>
        public void Test2()
        {
            for (int i = 30; i < 50; i++)
            {
                Log.Info("Thread2 Started");
                Log.Info("Test2:" + i);
                Log.Info("Thread is going to sleep");
                Thread.Sleep(10000);
                Log.Info("Thread Wokeup");
                Log.Info("Thread2 Exiting");
            }
       }
        /// <summary>
        /// create Test3()
        /// </summary>
        public void Test3()
        {
            for (int i = 50; i < 70; i++)
            {
                Log.Info("Thread3 Started");
                Log.Info("Test3:" + i);
                Log.Info("Thread3 Exiting");
            }

        }
    }
    /// <summary>
    /// creating another class
    /// </summary>
    class Sample2
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// In the main method creating instances for multiple threads
        /// The thread instantiation can be done internally
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Log.Info("Main Thread Started");
            ThreadDemoo obj = new ThreadDemoo();
            Thread T1 = new Thread(obj.Test1); 
            Thread T2 = new Thread(obj.Test2);
            Thread T3 = new Thread(obj.Test3);
            T1.Start();
            T2.Start();
            Log.Info("Main Thread Exiting");
        }
    }
}

//In this framework intrenally creating the instances