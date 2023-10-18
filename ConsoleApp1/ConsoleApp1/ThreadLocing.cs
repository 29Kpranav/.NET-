using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class ThreadLocking
    {

        public void Display()
        {
            lock (this)
            {
                Console.WriteLine("CSharp is an");
                Thread.Sleep(5000);
                Console.WriteLine("Object Oriented Language");
            }
        }

        static void Mainnn(string[] args) {
            ThreadLocking obj = new ThreadLocking();
            obj.Display();
            obj.Display();
            obj.Display();
            Console.ReadLine(); 
        }
    }
}

// to avoid collision of data from diffrent threads we use threadLocking 
// after execution of first thread control goes to second thread untill it will not accessible
