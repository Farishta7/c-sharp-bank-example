using System;
using System.Text; //This is here so that "StringBuilder();" can be used

namespace MySuperBank // Note: actual namespace depends on the project name.
{
    public class BankAccount
    {
        public string Number { get; } // you can write this line by starting to type "prop" and then click "tab" and edit and then click "tab" again to move onto next word to edit it to what you desire.
        public string Owner { get; set; } // We wrote for all of them "public" because then other applications and other classes within our applicatyion can look at those and talk to those. Making it private won't allow this to happen.
        public decimal Balance
        {
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

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Amount of deposit must be positive"
                );
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Amount of withdrawal must be positive"
                );
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // HEADER
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                // ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
