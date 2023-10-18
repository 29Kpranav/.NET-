using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class MThread1
    {
        static void Maink(string[] args)
        {
            Thread t = Thread.CurrentThread;
            t.Name = "Main Thread";
            Console.WriteLine("Current executing thread is :" +Thread.CurrentThread.Name);
        }
    }
}
