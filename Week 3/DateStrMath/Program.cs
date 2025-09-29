using System;

class Program
{
    public static void Main()
    {
        // ---------------------------DATE ----------//
        // current date and time 
        DateTime now = DateTime.Now;
        Console.WriteLine($"Roght now, the date and time is {now}");

        // current date
        Console.WriteLine($"Date {DateTime.Today.ToShortDateString()}");
        // .ToShortTimeString()

        // Create specific date
        DateTime birthday = new DateTime(2004, 5, 12);
        Console.WriteLine("Birthday: " + birthday.ToString("dd/MM/yyyy"));

        // Add days/months/years
        Console.WriteLine("10 days later: " + now.AddDays(10));
        Console.WriteLine("2 months earlier: " + now.AddMonths(-2));

        // Difference between dates
        TimeSpan age = now - birthday;
        Console.WriteLine("Days lived: " + age.Days);



        // ---------------------------STRING ----------//
        string name = "  Hello World  ";

        // Length
        Console.WriteLine("Length: " + name.Length);

        // Trim spaces
        Console.WriteLine("Trimmed: '" + name.Trim() + "'");

        // Upper & Lower case
        Console.WriteLine("Upper: " + name.ToUpper());
        Console.WriteLine("Lower: " + name.ToLower());

        // Substring
        Console.WriteLine("Substring(2,5): " + name.Substring(2, 5));

        // Replace
        Console.WriteLine("Replace World with C#: " + name.Replace("World", "C#"));

        // Contains 
        Console.WriteLine("Contains 'Hello'? " + name.Contains("Hello"));

        // Split into array
        string csv = "red,green,blue";
        string[] colors = csv.Split(',');
        Console.WriteLine("First color: " + colors[0]);

        // ---------------------------MATH ----------//
        Console.WriteLine("Absolute: " + Math.Abs(-25));       // 25
        Console.WriteLine("Max: " + Math.Max(10, 20));         // 20
        Console.WriteLine("Min: " + Math.Min(10, 20));         // 10

        Console.WriteLine("Square root: " + Math.Sqrt(16));    // 4
        Console.WriteLine("Power: " + Math.Pow(2, 3));         // 8

        Console.WriteLine("Round 3.6: " + Math.Round(3.6));    // 4
        Console.WriteLine("Ceiling 3.2: " + Math.Ceiling(3.2));// 4
        Console.WriteLine("Floor 3.8: " + Math.Floor(3.8));    // 3

        Console.WriteLine("PI: " + Math.PI);                   // 3.141592...
        Console.WriteLine("E: " + Math.E);                     // 2.718...

        Console.WriteLine("Cos(0): " + Math.Cos(0));           // 1
        Console.WriteLine("Sin(0): " + Math.Sin(0));           // 0

    }
}