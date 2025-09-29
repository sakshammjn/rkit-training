using System;

namespace LibraryDemo
{
    // Program entry
    class Program
    {
        static void Main()
        {
            Book book = new Book("C# Programming", "John Doe", "12345", 2022, "Programming");

            Console.WriteLine("=== Access from Book object ===");

            Console.WriteLine($"Title: {book.Title}");             // ✅ Public
            // Console.WriteLine(book.ISBN);                      // ❌ Private
            // Console.WriteLine(book.YearPublished);             // ❌ Protected
            Console.WriteLine($"Genre: {book.Genre}");             // ✅ Internal
            book.ShowISBN();                                       // ✅ Access private via method

            Console.WriteLine("\n=== Access from Member (Derived) ===");

            Member member = new Member("C# Programming", "John Doe", "12345", 2022, "Programming", "Alice");
            member.ShowMemberDetails();

            Console.WriteLine("\n=== Access from Librarian (not derived) ===");
            Librarian librarian = new Librarian();
            librarian.ShowLibrarianAccess();
        }
    }
}