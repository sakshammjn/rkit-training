using System.Diagnostics.Contracts;

namespace webAPI.Models
{
    public enum AccountType
    {
        Min,
        Sub
    }
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Number { get; set; }  
        public AccountType AccountType { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
