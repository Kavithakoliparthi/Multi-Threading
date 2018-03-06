using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThreading
{
    /// <summary>
    /// create class SpinWaitDemo
    /// </summary>
    class SpinWaitDemo
    {
        /// <summary>
        /// creating a log
        /// </summary>
        static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// craete NestedTask method
        /// </summary>
        static void SimpleNestedTask()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                log.Info("Outer task executing.");

                var child = Task.Factory.StartNew(() =>
                {
                    log.Info("Nested task starting.");
                    Thread.SpinWait(30000);
                    //causes a thread to wait number of times defined by iterations parameter
                    log.Info("Nested task completing.");
                });
            });
            parent.Wait();
            log.Info("Outer has completed.");
        }
        /// <summary>
        /// main method is the starting point of program execution
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SimpleNestedTask();
            Console.ReadLine();
        }
    }
}


//Task.Factory.StartNew, gives you the opportunity to define
//a lot of useful things about the thread you want to create, 
//while Task.Run doesn't provide this.

//A newly created thread that would be dedicated to this task and
//would be destroyed once your task would have been completed. 
//You cannot achieve this with the Task.Run
//Task.Run has been introduced in latest version(4.5v)
