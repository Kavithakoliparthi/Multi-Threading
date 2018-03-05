using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    /// <summary>
    /// Creating a class
    /// </summary>
    class ThreadDemo4
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Creating a Test1()
        /// </summary>
        public void Test1()
        {
            Log.Info("Thread1 Started");
            for (int i=1;i<20;i++)
            {
                Log.Info("Test1:" + i);
            }
            Thread.Sleep(4000);
            Log.Info("Thread1 Exist");
        }
        /// <summary>
        /// Creating Test2()
        /// </summary>
        public void Test2()
        {
            Log.Info("Thread2 Started");
            for (int i=30;i<50;i++)
            {
                Log.Info("Test2:" + i);
            }
            Log.Info("Thread2 Ended");
        }
    }
    /// <summary>
    /// Creating another class
    /// </summary>
    class Sample5
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Creaing a main method
        /// main method is strating point of the program
        /// In this method we can call join().
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Log.Info("Main Thread Started");
            ThreadDemo4 obj = new ThreadDemo4();
            Thread T1 = new Thread(obj.Test1);
            Thread T2 = new Thread(obj.Test2);
            T1.Start();
            T2.Start();
            T1.Join(2000);
            T2.Join();
            
            Log.Info("Main Thread Exist");
        }
    }
}
