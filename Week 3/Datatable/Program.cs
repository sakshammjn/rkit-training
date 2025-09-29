using System;
using System.Data;

namespace DataTableDemo
{
    class Program
    {
        // Helper method to display DataTable
        static void DisplayTable(DataTable table)
        {
            Console.WriteLine("ID\tName\tAge\tGrade");
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["ID"]}\t{row["Name"]}\t{row["Age"]}\t{row["Grade"]}");
            }
        }
        static void Main()
        {
            Console.WriteLine("=== Creating and Using DataTable ===\n");

            // Create a DataTable
            DataTable studentsTable = new DataTable("Students");

            // Add Columns (define type)
            studentsTable.Columns.Add("ID", typeof(int));
            studentsTable.Columns.Add("Name", typeof(string));
            studentsTable.Columns.Add("Age", typeof(int));
            studentsTable.Columns.Add("Grade", typeof(string));

            // Add Rows
            studentsTable.Rows.Add(1, "Saksham", 20, "A");
            studentsTable.Rows.Add(2, "Ruchika", 21, "B");
            studentsTable.Rows.Add(3, "Barkha", 19, "A");
            studentsTable.Rows.Add(4, "Nisarg", 22, "C");
            studentsTable.Rows.Add(5, "Aryan", 20, "B");

            // Display DataTable
            Console.WriteLine("All Students:");
            DisplayTable(studentsTable);

            // Access single cell
            Console.WriteLine($"\nFirst student name: {studentsTable.Rows[0]["Name"]}");

            // Filter rows
            Console.WriteLine("\nStudents with Grade A:");
            DataRow[] gradeAStudents = studentsTable.Select("Grade = 'A'");
            foreach (DataRow row in gradeAStudents)
            {
                Console.WriteLine($"{row["Name"]} - {row["Grade"]}");
            }

            // Modify a value
            Console.WriteLine("\nUpdating saksham's Grade to B...");
            DataRow sakshamRow = studentsTable.Select("Name = 'Saksham'")[0];
            sakshamRow["Grade"] = "B";
            DisplayTable(studentsTable);

            // 9️⃣ Remove a row
            Console.WriteLine("\nRemoving aryan from table...");
            DataRow aryanRow = studentsTable.Select("Name = 'Aryan'")[0];
            studentsTable.Rows.Remove(aryanRow);
            DisplayTable(studentsTable);
        }
    }
}