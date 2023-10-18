using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Reflection
    {
        static void Main(string[] args)
        {
            Type s = typeof(String);
            Console.WriteLine(s.Name);
            Console.WriteLine(s.FullName);
            Console.WriteLine(s.BaseType);
            Console.WriteLine(s.Namespace);
            Console.WriteLine(s.IsClass);
            Console.WriteLine(s.GetHashCode);
        }
    }
}
