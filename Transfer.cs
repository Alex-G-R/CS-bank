using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Transfer
    {
        public decimal Amount { get; }
        public string Recipient { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transfer(decimal amount, string recipent, DateTime date, string notes)
        {
            this.Amount = amount;
            this.Recipient = recipent;
            this.Date = date;
            this.Notes = notes;
        }
    }
}
