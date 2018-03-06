using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// create ResetEventDemo class
    /// </summary>
    class ResetEventDemo
    {
        /// <summary>
        /// creating a log
        /// </summary>
        static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //AutoReset and ManualReset Events are the sealed classes impleted from EventWaitHandle
        static AutoResetEvent objAuto = new AutoResetEvent(false);
        static ManualResetEvent objAuto1 = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Process();
        }
        public static void Process()
        {
            new Thread(Test).Start();
            Console.ReadLine();
            objAuto.Set();
            Console.ReadLine();
            objAuto.Set();

            Console.ReadLine();
            objAuto1.Set();
            Console.ReadLine();
            objAuto1.Set();
        }
        static void Test()
        {
            log.Info("starting 1 for AutoResetEvent");
                //blocks the current thread until current wait handle receives the signal
            objAuto.WaitOne();
            log.Info("Finishing 1 for AutoResetEvent");

            log.Info("starting 2 for AutoResetEvent");
            objAuto.WaitOne();
            log.Info("Finishing 2for AutoResetEvent");

            log.Info("starting 1 for ManualResetEvent");
            objAuto1.WaitOne();
            log.Info("Finishing 1 for ManualResetEvent");

            log.Info("starting 2 for ManualResetEvent");
            objAuto1.WaitOne();
            log.Info("Finishing 2 for ManualResetEvent");
        }
    }
}

// Multiple threads can enter into a waiting/blocking state by 
//calling the WaitOne method on ManualResetEvent object. 
//When controlling thread calls the Set method all the waiting threads
 //are unblocked and free to proceed * /
