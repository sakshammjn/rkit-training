using System;
// using SchoolNamespace;
// using CollegeNamespace;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            SchoolNamespace.Student school = new SchoolNamespace.Student();
            school.showInfo();

            CollegeNamespace.Student college = new CollegeNamespace.Student();
            college.showInfo();

            new CollegeNamespace.nestedNamespace.randomNested();
        }
    }
}