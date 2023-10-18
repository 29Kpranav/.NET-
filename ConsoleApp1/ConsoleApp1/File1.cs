using System;
using System.IO;

class File1
{
    static void Mainx()
    {
        // File path
        string filePath = "C:\\Users\\MAYUR\\source\\repos\\ConsoleApp1\\ConsoleApp1\\example.txt";

        // Read data from file
        ReadFromFile(filePath);

        // Write data to file
        WriteToFile(filePath);

        // Read the updated data from file
        ReadFromFile(filePath);
    }


    /// <summary>
    /// Read and Write Code in this file 
    /// </summary>
    /// <param name="filePath"></param>
    static void ReadFromFile(string filePath)
    {
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Display the contents of the file
            Console.WriteLine("File Contents:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading from file: " + ex.Message);
        }
    }

    static void WriteToFile(string filePath)
    {
        try
        {
            // Prompt the user for input
            Console.WriteLine("Enter text to write to file:");
            string input = Console.ReadLine();

            // Write the input to the file
            File.WriteAllText(filePath, input);

            Console.WriteLine("Data written to file successfully!");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }
}