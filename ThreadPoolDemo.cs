using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThreading
{
    //craeting ThreadPoolDemoclass
    class ThreadPoolDemo
    {
        /// <summary>
        /// creating a log
        /// </summary>
        static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Main method is the starting point of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //QueueWorkItem is a method. It executes when a threadpool thread becomes availiable
            ThreadPool.QueueUserWorkItem(TestThread1);
            ThreadPool.QueueUserWorkItem(TestThread2);
            Console.ReadLine();
        }
        /// <summary>
        /// create TestThread1
        /// </summary>
        /// <param name="threadContext"></param>
        public static void TestThread1(Object threadContext)
        {
            int count = 0;
            
            while (++count < 10)
            {
                 log.Info("Thread 1 Executed" + count +"times");
                //Console.WriteLine("Thread 1 Executed"+count+"times");
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// create TestThread2
        /// </summary>
        /// <param name="threadContext"></param>
        public static void TestThread2(Object threadContext)
        {
            
            int count = 0;
            
            while (count++ < 5)
            {
                log.Info("Thread 2 Executed"+ count +"times");
                //Console.WriteLine("Thread 2 Executed"+count+"times");
                Thread.Sleep(100);
            }
        }
    }
}
