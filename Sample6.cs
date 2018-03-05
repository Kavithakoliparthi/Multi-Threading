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
    class ThreadDemo8
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Creating Test1()
        /// </summary>
        public void Test1()
        {
            Log.Info("Test1 started");
            Thread.Sleep(50000);
            Log.Info("Test1 function return");
        }
        /// <summary>
        /// Creating Test2()
        /// </summary>
        public void Test2()
        {
            Log.Info("Test2 started");
        }
    }
    /// <summary>
    /// Creating  class
    /// </summary>
    class Sample6
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Creating a main method
        /// OIt is starting point of the program execution
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Log.Info("Main method started");
            ThreadDemo8 obj = new ThreadDemo8();
            Thread T1 = new Thread(obj.Test1);
            Thread T2 = new Thread(obj.Test2);
            T1.Start();
            T2.Start();
            if (T2.IsAlive)
            {
                Log.Info("Test2 function is still workig");
            }
            else
            {
                Log.Info("Test2 function is not working");
            }
            T1.Join();
            Log.Info("Test1 exist");
            T2.Join();
            Log.Info("Test2 exist");
            if(T1.IsAlive)
            {
                Log.Info("Test1 function is still working");
            }
            else
            {
                Log.Info("Test1 function is not working");
            }
            Log.Info("Main method terminated");
        }
    }
}
