using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class MThread5
    {
        static void Test1() {
            Console.WriteLine("Thread 1 is Starting");
            for (int i=1;i<=25; i++)
            {
                Console.WriteLine("Test 1 :"+i);
            }
            Console.WriteLine("Thread 1 is Exiting");
        }

        static void Test2()
        {
            Console.WriteLine("Thread 2 is Starting");
            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine("Test 2 :" + i);
            }
            Console.WriteLine("Thread 2 is Exiting");
        }

        static void Test3()
        {
            Console.WriteLine("Thread 3 is Exiting");
            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine("Test 3 :" + i);
            }
            Console.WriteLine("Thread 3 is Exiting");
        }

        static void Mainv(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            Thread t1 = new Thread(Test1);
            Thread t2 = new Thread(Test2);
            Thread t3 = new Thread(Test3);
            t1.Start();
            t2.Start();
            //t2.Abort();
            t3.Start();
            //t1.Join(3000);t2.Join();t3.Join();
            t1.Priority = ThreadPriority.Lowest;
            Console.WriteLine("Main Thread Exiting");
        }
         
    }
}

// here main thread exiting at any time in the middle of other execution
// if you want to wait main thread executing until other threads complete therir work we use join
// let say you apply t1 to join until t1 exited main thread can't exited 
// join have overloaded method 
// when we give time to join main thread will wait only until that time period after exiting 
// every thread runs in normal priority