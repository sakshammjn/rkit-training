console.log("starts from here...");


//class creation
class BankAccount {
  static bankName = "State Bank of India";

  //private access modifier 
  #balance;

  //public member
  accountHolderName;

  constructor(accountHolderName, initialBalance) {
    this.accountHolderName = accountHolderName; 
    this.#balance = initialBalance;
  }


  deposit(amount) {
    this.#balance += amount;
    console.log(`${amount} deposited into ${this.accountHolderName}'s account`);
  }


  withdraw(amount) {
    if (amount > this.#balance) {
      console.log("Insufficient balance");
      return;
    }
    this.#balance -= amount;
    console.log(`${amount} withdrawn from ${this.accountHolderName}'s account`);
  }

  getBalance() {
    return this.#balance;
  }

  static getBankName() {
    return BankAccount.bankName;
  }
}




//object creation
const account1 = new BankAccount("Saksham", 5000);
const account2 = new BankAccount("Aman", 3000);
const account3 = new BankAccount("Jay", 7000);



account1.deposit(2000); // 1->7000
account1.withdraw(1000); // 1->6000

account2.deposit(500); // 2->3500

account3.withdraw(5000); //3->2000
account3.withdraw(4000); // insufficient balance



console.log("Account 1 Balance:", account1.getBalance()); // 6000
console.log("Account 2 Balance:", account2.getBalance()); // 3500
console.log("Account 3 Balance:", account3.getBalance()); // 2000

console.log("Bank Name using static ethod and no object declaration:", BankAccount.getBankName());

