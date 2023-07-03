// See https://aka.ms/new-console-template for more information

using System;

namespace MySuperBank // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("kendra", 10000);
            
            Console.WriteLine(
                $"Account {account.Number} was created for {account.Owner} with {account.Balance}."
            );

            account.MakeWithdrawal(120, DateTime.Now, "Hammock");

            // Console.WriteLine(account.Balance);

            account.MakeWithdrawal(50, DateTime.Now, "game");

            // Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());






            // // Test for a negative balance.
            // try
            // {
            //     account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            // }
            // catch (InvalidOperationException e)
            // {
            //     Console.WriteLine("Exception caught trying to overdraw");
            //     Console.WriteLine(e.ToString());
            // }

            // // Test that the initial balances must be positive.
            // BankAccount invalidAccount;
            // try
            // {
            //     invalidAccount = new BankAccount("invalid", -55);
            // }
            // catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exception caught creating account with negative balance");
            //     Console.WriteLine(e.ToString());
            //     return;
            // }

            
        }
    }
}
