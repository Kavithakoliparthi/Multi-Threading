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
    class ThreadDemo6
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// creating lock block
        /// </summary>
        public void Display()
        {
            //lock (this)
            //{
            //    Log.Info("C Shrap is an");
            //    Thread.Sleep(5000);
            //    Log.Info("object oriented language");
            //}
            Monitor.Enter(this);
            try
            {
                Log.Info("C sharp is an");
                Thread.Sleep(3000);
                Log.Info("object oriented language");
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
    /// <summary>
    /// Creaing a class
    /// </summary>
    class ThreadLockingDemo1
    {
        /// <summary>
        /// Creating main method
        /// It is the starting point of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ThreadDemo6 obj = new ThreadDemo6();
            Thread t1 = new Thread(obj.Display);
            Thread t2 = new Thread(obj.Display);
            t1.Start();
            t2.Start();
        }
    }
}
