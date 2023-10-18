using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class arrays
    {
        static void Main2(string[] args)
        {
            int[] myNum = { 10, 20, 30, 40 };
            
            // Create an array of four elements, and add values later
            string[] cars = new string[4];

            // Create an array of four elements and add values right away 
            string[] cars1 = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements without specifying the size 
            string[] cars2 = new string[] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements, omitting the new keyword, and without specifying the size
            string[] cars3 = { "Volvo", "BMW", "Ford", "Mazda" };

            foreach (string i in cars2)
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < cars3.Length; i++)
            {
                Console.WriteLine(cars3[i]);
            }

            int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };
            Console.WriteLine(numbers[0, 2]);  // Outputs 2

            int[,] number = { { 1, 4, 2 }, { 3, 6, 8 } };

            for (int i = 0; i < number.GetLength(0); i++)
            {
                for (int j = 0; j < number.GetLength(1); j++)
                {
                    Console.WriteLine(number[i, j]);
                }
            }

            int time = 20;
            string result = (time < 18) ? "Good day." : "Good evening.";
            Console.WriteLine(result);

            int day = 4;
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
            }
        }
    }
}
