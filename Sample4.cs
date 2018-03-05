using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    /// <summary>
    /// craeting a class with parameterized method
    /// </summary>
    class ThreadDemo2
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// creating a parameterized Test()
        /// </summary>
        /// <param name="obj"></param>
        public void Test(Object obj)
        {
            for(int i=1;i<=30;i++)
            {
                Log.Info("Test:" + i);
            }
        }
    }
    /// <summary>
    /// craeting anothet class
    /// </summary>
    class Sample4
    {
        /// <summary>
        /// Creating a main method
        /// In the main method we can explicitly create the thread instantiation
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ThreadDemo2 obj = new ThreadDemo2();
            ParameterizedThreadStart ts = new ParameterizedThreadStart(obj.Test);
            Thread t = new Thread(ts);

            //ParameterizedThreadStart obj = delegate () { t1.Test(); };
                //Through lambda expressions
            //ParameterizedThreadStart obj = () => t1.Test();
            t.Start(40);
        }
    }
}
