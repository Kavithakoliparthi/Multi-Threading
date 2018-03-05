using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    class Sample1
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Test()
        {
            Log.Info("This is test method");
        }
    }
    class LifeCycleDemo
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Sample1 obj = new Sample1();
            Log.Info("Thread state is:");
            Thread t1 = new Thread(obj.Test);
            t1.Start();
        }
    }
}
