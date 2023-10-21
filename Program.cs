using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            var account = new BankAccount("Alex", 76500);

            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance}.");


            account.MakeWithdrawal(124, DateTime.Now, "Leafblower");

            account.MakeTransfer(500, "Big Mike", DateTime.Now, "For food");


            Console.WriteLine(account.GetAccountHistory());
        } 
    }
}