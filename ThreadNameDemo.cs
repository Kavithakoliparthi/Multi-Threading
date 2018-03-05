using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
    class ThreadDemo9
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Thread1()
        {
            Thread t = Thread.CurrentThread;
            Log.Info(t.Name+"is running");
        }
    }
    class ThreadNameDemo
    {
        static void Main(string[] args)
        {
            ThreadDemo9 obj = new ThreadDemo9();
            Thread t1 = new Thread(obj.Thread1);
            Thread t2 = new Thread(obj.Thread1);
            t1.Name="First Thread";
            t2.Name = "Second Thread";
            t1.Start();
            t2.Start();
        }
    }
}
