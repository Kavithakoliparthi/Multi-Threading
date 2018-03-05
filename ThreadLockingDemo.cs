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
    class ThreadDemo5
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Creating a Display()
        /// </summary>
        public void Display()
        {
            Log.Info("C Shrap is an");
            Thread.Sleep(5000);
            Log.Info("object oriented language");            
        }
    }
    /// <summary>
    /// Creating another class
    /// </summary>
    class ThreadLockingDemo
    {
        /// <summary>
        /// Creating main method
        /// It is the starting point of execution
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ThreadDemo5 obj = new ThreadDemo5();
            Thread t1=new Thread(obj.Display);
            Thread t2=new Thread(obj.Display);
            t1.Start();
            t2.Start();
        }
    }
}
