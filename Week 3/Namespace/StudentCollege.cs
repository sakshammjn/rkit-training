using System;

namespace CollegeNamespace
{
    public class Student
    {
        public string name = "Mahajan";

        public void showInfo()
        {
            Console.WriteLine($"Name: {name} (from CollegeNamespace)");
        }
    }

    namespace nestedNamespace
    {
        public class randomNested
        {
            public randomNested()
            {
                Console.WriteLine("This is inside nested namespace");
            }
        }
    }
}