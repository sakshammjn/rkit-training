using System;

namespace SchoolNamespace
{
    public class Student
    {
        public string name = "Saksham";

        public void showInfo()
        {
            Console.WriteLine($"Name: {name} (from SchoolNamespace)");
        }
    }
}