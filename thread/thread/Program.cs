﻿using System;
using System.Threading;
namespace MonitorDemo
{
    class Program
    {
        private static readonly object lockPrintNumberst = new object();

        public static void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section");
            bool IsLockTaken = false;

            try
            {
                Monitor.Enter(lockPrintNumberst, ref IsLockTaken);
                if (IsLockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(i + ",");
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                if (IsLockTaken)
                {
                    Monitor.Exit(lockPrintNumberst);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
                }
            }
        }

        static void Main(string[] args)
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(PrintNumbers)
                {
                    Name = "Child Thread " + i
                };
            }

            foreach (Thread t in Threads)
            {
                t.Start();
            }

            Console.ReadLine();
        }
    }
}