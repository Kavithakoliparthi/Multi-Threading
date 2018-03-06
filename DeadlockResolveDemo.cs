using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThreading
{
    /// <summary>
    /// craete Account class
    /// </summary>
    class Account
    {
        /// <summary>
        /// creating id, balence variables
        /// </summary>
        int id;
        double balence;
        /// <summary>
        /// create Parameterized constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="balence"></param>
        public Account(int id, double balence)
        {
            this.id = id;
            this.balence = balence;
        }
        /// <summary>
        /// get id
        /// </summary>
        public int ID
        {
            get { return id; }
        }
        /// <summary>
        /// craete Withdraw()
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(double amount)
        {
            balence -= amount;
        }
        /// <summary>
        /// create Deposit()
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(double amount)
        {
            balence += amount;
        }
    }
    /// <summary>
    /// creating account manager class
    /// </summary>
    class AccountManager
    {
        /// <summary>
        /// creating a log
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// creating fromAccount, toAccount
        /// </summary>
        Account fromAccount;
        Account toAccount;
        double amountTransfer;
        /// <summary>
        /// craete parameterized constructor
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="toAccount"></param>
        /// <param name="amountTrasfer"></param>
        public AccountManager(Account fromAccount, Account toAccount, double amountTrasfer)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            this.amountTransfer = amountTransfer;
        }
         /// <summary>
        /// create Transfer()
        /// </summary>
        public void Transfer()
        {
            object lock1, lock2;
            if(fromAccount.ID < toAccount.ID)
            {
                lock1 = fromAccount;
                lock2 = toAccount;
            }
            else
            {
                lock1 = toAccount;
                lock2 = fromAccount;
            }
            log.Info(Thread.CurrentThread.Name + " trying to acquire lock on" + ((Account)lock1).ID.ToString());
            lock (lock1)
            {
                log.Info(Thread.CurrentThread.Name + "tring to acquire lock on" + ((Account)lock1).ID.ToString());
                log.Info(Thread.CurrentThread.Name + "suspended for 2 seconds");
                Thread.Sleep(1000);
                log.Info(Thread.CurrentThread.Name + "back in action and tryng to acquire lock on" + ((Account)lock2).ID.ToString());
                lock (lock2)
                {
                    log.Info(Thread.CurrentThread.Name+"acquire lock on"+ ((Account)lock2).ID.ToString());
                    fromAccount.Withdraw(amountTransfer);
                    toAccount.Deposit(amountTransfer);

                }
            }
        }
    }
    /// <summary>
    /// creating DeadLockResolveDemo class
    /// </summary>
    class DeadlockResolveDemo
    {
        /// <summary>
        /// creating a log
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Process();
            Console.ReadLine();
        }
        /// <summary>
        /// craete Process()
        /// </summary>
        public static void Process()
        {
            log.Info("main thread started");
            Account a1 = new Account(1234, 6000);
            Account a2 = new Account(7891, 9000);

            AccountManager am1 = new AccountManager(a1, a2, 3000);
            Thread T1 = new Thread(am1.Transfer);
            T1.Name = "T1";
            AccountManager am2 = new AccountManager(a2, a1, 2000);
            Thread T2 = new Thread(am2.Transfer);
            T2.Name = "T2";
            T1.Start();
            T2.Start();
            T1.Join();
            T2.Join();
            log.Info("Main threaded ended");
        }
    }
}
