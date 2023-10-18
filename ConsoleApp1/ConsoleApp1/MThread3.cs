using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class MThread3
    {
        static void Test1()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test1:" + i);
            }
            Console.WriteLine("thread 1 is excuting..");
        }

        static void Mainpq(string[] args)
        {
            Thread t1 = new Thread(Test1);  //we we pass method here internally it will create delegate called as ThreadStart  and pass it as a parameter
            
            t1.Start();
           
            Console.WriteLine("Main thread is executing..");
        }
    }
}

/*
  
* ThreadStart obj = new ThreadStart(Test1); 
  Thread t = new Thread(obj);
          or
  Thread t = new Thread(Test);


* ThreadStart obj = new ThreadStart(Test1);
          or
  ThreadStart obj = Test;
          or
  ThreadStart obj = delegate(){ Test(); };
          or
  ThreadStart obj =() => Test();  //lamda operator 


Instanciation of delegate is process of binding method with delegate  
if you dont perform it clr will implicitly perform
*/