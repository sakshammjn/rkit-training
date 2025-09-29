using System;

class Program
{
    enum SubjectNames
    {
        Math,
        English,
        Chemistry = 10,
        Physics,
        French
    }
    
    public enum Priority : byte
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Math at index " + (int)SubjectNames.Math);
        Console.WriteLine("English at index " + (int)SubjectNames.English);
        Console.WriteLine("Physics at index " + (int)SubjectNames.Physics);
        Console.WriteLine("French at index " + (int)SubjectNames.French);

        Priority taskPriority = Priority.Critical;
        Console.WriteLine("Task Priority: "+ taskPriority);
        Console.WriteLine("Numeric value: "+ (byte)taskPriority); // 4
    }
}