using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class MThread2
    {
        static void Test1()
        {
            for(int i=1; i<=100; i++)
            {
                Console.WriteLine("Test1:" + i);
            }
            Console.WriteLine("thread 1 is excuting..");
        }

        static void Test2()
        {
            for(int i=1; i<=100; i++)
            {
                Console.WriteLine("Test2:" + i);
                if(i == 50)
                {
                    Console.WriteLine("Thread2 is going to sleep");
                    Thread.Sleep(5000);   //sleep is static method can't called by instance like t2.sleep() can call by class name
                    Console.WriteLine("Thread2 woke up");
                }
            }
            Console.WriteLine("thread 2 is executing..");
        }

        static void Test3() 
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test3 :" + i);
            }

            Console.WriteLine("thread 3 is executing..");
        }

        static void Mainp(string[] args)
        {
            Thread t1 = new Thread(Test1);  //we we pass method here internally it will create delegate called as ThreadStart  and pass it as a parameter
            Thread t2 = new Thread(Test2);
            Thread t3 = new Thread(Test3);  // we have 4 threads now

            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Main thread is executing..");
        }
    }
}
