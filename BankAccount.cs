using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get 
            {
                decimal balance = 0;
                foreach (var item in allTransactions) 
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        private static int accountNumberSeed = 1234567890;


        private List<Transaction> allTransactions = new List<Transaction>();
        private List<Transfer> allTransfers = new List<Transfer>();


        public BankAccount(string name, decimal initalBalance)
        {
            this.Owner = name;

            MakeDeposit(initalBalance, DateTime.Now, "Initial Balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            { 
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be possitive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Your withdraw must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You are broke");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public void MakeTransfer(decimal amount, string recipent, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Your transfer must be positive");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("You are broke");
            }
            var transfer = new Transfer(-amount, recipent, date, note);
            allTransfers.Add(transfer);
        }


        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // Header
            report.AppendLine("\n");
            report.AppendLine("Transactions Deposit/Withdrawal");
            report.AppendLine("Date\t\tAmonut\t\tNote");

            foreach(var transaction in allTransactions)
            {
                // Report rows
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t\t{transaction.Notes}");
            }
            report.AppendLine("\n");
            report.AppendLine("Transfer history");
            report.AppendLine("Date\t\tRecipent\tAmonut\t\tNote");

            foreach (var transfer in allTransfers)
            {
                // Report rows
                report.AppendLine($"{transfer.Date.ToShortDateString()}\t{transfer.Recipient}\t{transfer.Amount}\t\t{transfer.Notes}");
            }
            return report.ToString();
        }
    }
}
