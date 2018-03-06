using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// creating NestedLockDemo class
    /// </summary>
    class NestedLockDemo
    {
        /// <summary>
        /// creating log
        /// </summary>
        static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        ///create a and b instances
        /// </summary>
        object a = new object();
        object b = new object();
        /// <summary>
        /// Test is a method
        /// </summary>
        void Test()
        {
            lock (a) 
            {
                log.Info("from lock a");
            }
        }
        void doStuff()
        {
            lock (b)
            {
                   Test();
            }
        }
        /// <summary>
        /// Mainmethod
        /// It is the starting point of execution
        /// </summary>
        static void Main()
        {
            NestedLockDemo obj = new NestedLockDemo();
            obj.doStuff();
        }
    }
}
