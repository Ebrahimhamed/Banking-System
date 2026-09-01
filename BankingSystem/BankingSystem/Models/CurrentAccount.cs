using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Models
{
    internal class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(int accountNumber, Customer? customer):base(accountNumber,customer)
        {
            OverdraftLimit = 500;
        }
        public override bool Withdraw(decimal amount)
        {
            if(amount <= 0) return false;
            if (OverdraftLimit+Balance>=amount)
            {
                Balance -= amount;
                Transaction transaction = new Transaction(amount, TransactionType.Withdraw, this);
                Transactions.Add(transaction);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"account number: {AccountNumber}, account type: currentaccount ,account owner:{Customer?.Name},balance:{Balance}";
        }
    }
}
