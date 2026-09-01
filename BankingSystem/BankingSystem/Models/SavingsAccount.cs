using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Models
{
    internal class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(int accountNumber, Customer? customer) : base(accountNumber, customer) 
        {
            InterestRate = 10;
        }
        public override bool Withdraw(decimal amount)
        {
            if (amount>0&&amount <= Balance)
            {
                Balance-=amount;
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
            return $"account number: {AccountNumber}, account type: savingsaccount ,account owner:{Customer?.Name},balance:{Balance}";
        }
    }
    
}
