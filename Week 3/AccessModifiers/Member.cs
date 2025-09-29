using System;

namespace LibraryDemo
{
    public class Member : Book
    {
        public string MemberName;

        public Member(string title, string author, string isbn, int year, string genre, string memberName)
            : base(title, author, isbn, year, genre)
        {
            MemberName = memberName;
        }

        public void ShowMemberDetails()
        {
            Console.WriteLine("=== Member Details ===");
            Console.WriteLine($"Title: {Title}");               // ✅ Public
            // Console.WriteLine(ISBN);                        // ❌ Private
            Console.WriteLine($"Year Published: {YearPublished}"); // ✅ Protected
            Console.WriteLine($"Genre: {Genre}");               // ✅ Internal
            Console.WriteLine($"Member Name: {MemberName}");     // ✅ Public
        }
    }
}