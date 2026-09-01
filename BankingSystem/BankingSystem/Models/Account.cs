using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankingSystem.Models
{
    internal abstract class Account
    {
        

        #region properties
        public int AccountNumber { get; set; }

        public Customer? Customer { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Balance { get; protected set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        #endregion


        #region ctors
        protected Account(int accountNumber, Customer? customer)
        {
            AccountNumber = accountNumber;
            Customer = customer;
            CreatedAt= DateTime.Now;
        }
        #endregion
        #region methods
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            else
            {
                Balance += amount;
                Transaction transaction = new Transaction(amount, TransactionType.Deposit, this);
                Transactions.Add(transaction);
                return true;
            }
        }

        public abstract bool Withdraw(decimal amount);
        public bool Transfer(decimal amount, Account acc)
        {
            if (amount <= 0 || acc is null) return false;
            if (Balance < amount)
            {
                return false;
            }
            else
            {
                acc.Balance += amount;
                this.Balance -= amount;
                Transaction transaction = new Transaction(amount, TransactionType.Transfer, this);
                Transactions.Add(transaction);
                acc.Transactions.Add(transaction);

                return true;
            }

        }
        public void ShowBalance()
        {
            Console.WriteLine(Balance);
        }
        







        #endregion

    }
}
