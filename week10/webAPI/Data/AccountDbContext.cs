using webAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webAPI.Data
{
    public class AccountDbContext
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        private AccountDbContext()
        {
            Accounts = new List<Account>()
            {
                new Account() { AccountType= AccountType.Min, Id = 1, Name = "Acc1", Number = "AC1",
                    Cards = new List<Card>()
                    {
                        new Card {Id = 1, Number = "3443-4455-5566-6677", ExpiryDate = "06/28", HolderName = "Saksham"},
                        new Card {Id = 2, Number = "1122-2233-3344-4455", ExpiryDate = "09/30", HolderName = "Rajesh" }
                    }      
                },

                new Account() {AccountType= AccountType.Sub, Id = 2, Name = "Acc2", Number = "AC2",
                Cards = new List<Card>()
                    {
                        new Card {Id = 1, Number = "3443-4455-5566-6677", ExpiryDate = "06/28", HolderName = "Varun"},
                        new Card {Id = 2, Number = "1122-2233-3344-4455", ExpiryDate = "09/30", HolderName = "Kevin" }
                    } }
            };
        }

        public static AccountDbContext Current = new AccountDbContext();
    }
}
