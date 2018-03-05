using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    /// <summary>
    /// creating a ThreadTest1 class with default method
    /// </summary>
    class ThreadDemo1
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Create default Test()
        /// </summary>
        public void Test()
        {
            for(int i=1;i<30;i++)
            {
                Log.Info("Test:" + i);
            }
        }
    }
    /// <summary>
    /// creating another class and provide main method
    /// </summary>
    class Sample3
    {
        /// <summary>
        /// Main method is the starting point of execution
        /// In the main method we can explictly create thread instantiation
        /// The instantiation can be done through anonymous method, lambda expression
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ThreadDemo1 t1 = new ThreadDemo1();
            //ThreadStart obj = new ThreadStart(t1.Test);
            //ThreadStart obj = t1.Test;
                    //Through Delegates
            //ThreadStart obj = delegate () { t1.Test(); };
                    //Through lambda expressions
            ThreadStart obj = () => t1.Test();
           
            Thread t = new Thread(obj);
            t.Start();

        }
    }
}
