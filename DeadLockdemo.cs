using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Parallel_Programming
{
   class DeadLockDemo
    {
        static object firstLock = new object();
        static object secondLock = new object();
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void ThreadJob()
        {
            Console.WriteLine("Locking firstLock");
            lock (firstLock)
            {
                Log.Info("Locked firstLock");
                Thread.Sleep(1000);
                Log.Info("Locking secondLock");
                lock (secondLock)
                {
                    Log.Info("Locked secondLock");
                }
                Log.Info("Released secondLock");
            }
            Log.Info("Released firstLock");
        }

        static void Main()
        {
              new Thread(new ThreadStart(ThreadJob)).Start();
            Thread.Sleep(500);
            Console.WriteLine("Locking secondLock");
            lock (secondLock)
            {
                Console.WriteLine("Locked secondLock");
                Console.WriteLine("Locking firstLock");
                lock (firstLock)
                {
                    Console.WriteLine("Locked firstLock");
                }
                Console.WriteLine("Released firstLock");
            }
            Console.WriteLine("Released secondLock");
            Console.Read();
        }
    }
}
