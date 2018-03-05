using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Programming
{
    /// <summary>
    /// Single Thereaded Program
    /// </summary>
    class ThreadDemo
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// creating a default Test1()
        /// </summary>
        public void Test1()
        {
            for(int i=1;i<=50;i++)
            {
                Log.Info("Test1:" + i);
            }
        }
        /// <summary>
        /// Creating Test2()
        /// </summary>
        public void Test2()
        {
            for(int i=30;i<=50;i++)
            {
                Log.Info("Test2:" + i);
            }
        }
    }
    /// <summary>
    /// creating another class
    /// </summary>
    class Sample
    {
        /// <summary>
        /// main method 
        /// it is the starting point of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ThreadDemo obj = new ThreadDemo();
            obj. Test1();
            obj.Test2();
        }
    }
}
