using System;

namespace LibraryDemo
{
    public class Librarian
    {
        public void ShowLibrarianAccess()
        {
            Book book = new Book("C# Programming", "John Doe", "12345", 2022, "Programming");
            Console.WriteLine("=== Librarian Access ===");
            Console.WriteLine($"Title: {book.Title}");           // ✅ Public
            // Console.WriteLine(book.ISBN);                    // ❌ Private
            // Console.WriteLine(book.YearPublished);           // ❌ Protected
            Console.WriteLine($"Genre: {book.Genre}");           // ✅ Internal
        }
    }
}
