using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MThread4
    {

        static void test(object max)
        {
            int num = Convert.ToInt32(max);
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine("Test:" + i);
            }
        }

        static void Mainx(string[] args)
        {
            ParameterizedThreadStart obj = new ParameterizedThreadStart(test);  //

            Thread t = new Thread(obj); //its not typeSafe currently
            t.Start(60);   
            Console.ReadLine();
        }


    }
}
