
/*
In C#, a delegate is a type that represents a method or a group of methods with a specific signature. It provides a way to reference and invoke methods indirectly. Delegates are similar to function pointers in other programming languages.
Delegates are useful in scenarios where you want to pass a method as a parameter to another method, or when you want to implement events and event handling. They provide a level of abstraction and flexibility in designing code that needs to respond to different actions or events.
Here's a basic example to illustrate the concept of delegates in C#:
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Delegates
    {
        // Declare a delegate with a specific signature
        delegate int MathOperation(int a, int b);

        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        // Define methods that match the delegate signature
        int Add(int a, int b)
        {
            return a + b;
        }

        int Subtract(int a, int b)
        {
            return a - b;
        }

        // Define a method that takes a delegate as a parameter
        int PerformMathOperation(int a, int b, MathOperation operation)   
        {
            return operation(a, b);
        }


        #endregion //developers name and time
        static void Mainl(string[] args)
        {

            Delegates obj1 = new Delegates();

            // Create instances of the delegate and associate methods with them
            MathOperation addOperation = obj1.Add;
            MathOperation subtractOperation = obj1.Subtract;


            // Use the PerformMathOperation method with different operations
            int result1 = obj1.PerformMathOperation(5, 3, addOperation); // Performs addition
            int result2 = obj1.PerformMathOperation(8, 4, subtractOperation); // Performs subtraction

            Console.WriteLine("Result 1: " + result1); // Output: Result 1: 8
            Console.WriteLine("Result 2: " + result2); // Output: Result 2: 4
        }

    }
}
