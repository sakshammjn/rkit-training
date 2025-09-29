using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "sample.txt";
        string text1 = "this is the first text file created.\n";

        // overwrites
        File.WriteAllText(path, text1);

        Console.WriteLine("written successfully");

        string ans1 = File.ReadAllText("sample.txt");
        Console.WriteLine(ans1);

        // appends at the end
        string text2 = "this is the other line to be added.";
        File.AppendAllText(path, text2);

        string ans2 = File.ReadAllText("sample.txt");
        Console.WriteLine(ans2);

        Console.WriteLine();

        string[] lines = File.ReadAllLines("sample.txt");
        Console.WriteLine("Reading line by line:");
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }

        Console.WriteLine(lines[1]);

        // check if file exists 
        if (File.Exists("sample.txt"))
        {
            Console.WriteLine("File Exists");
        }

        // delete file 
        if (File.Exists("example.txt"))
        {
            File.Delete("example.txt");
            Console.WriteLine("File deleted successfully.");
        }

        // check if file exists 
        if (File.Exists("sample.txt"))
        {
            Console.WriteLine("File does not Exists");
        }
        


        // streamwriter and streamreader used when we want line by line operations, for larger files, eg logging systems
    }
}