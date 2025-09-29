using System;

namespace LibraryDemo
{
    public class Book
    {
        // Public: Accessible everywhere
        public string Title;
        public string Author;

        // Private: Accessible only within this class
        private string ISBN;

        // Protected: Accessible within this class and derived classes
        protected int YearPublished;

        // Internal: Accessible within the same assembly
        internal string Genre;

        // Constructor
        public Book(string title, string author, string isbn, int year, string genre)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublished = year;
            Genre = genre;
        }

        // Public method to access private ISBN
        public void ShowISBN()
        {
            Console.WriteLine($"ISBN: {ISBN}");
        }
    }
}