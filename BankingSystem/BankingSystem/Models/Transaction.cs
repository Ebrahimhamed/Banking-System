using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BankingSystem.Models
{
    internal class Transaction
    {
        #region attributes
        private static int idTransactionCounter = 0;
        #endregion
        #region properties
        public int TransactionId { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        public TransactionType Type { get; }
        public Account? FromAccount { get; }
        public Account? ToAccount { get; }
        #endregion

        #region ctors


        public Transaction(decimal amount, TransactionType type, Account? account1, Account? account2)
        {
            TransactionId = GetNewTransactionId();
            Amount = amount;
            Date = DateTime.Now;
            Type = type;
            FromAccount = account1;
            ToAccount = account2;
        }
        #endregion

        #region methods 
        private static int GetNewTransactionId()
        {
            return ++idTransactionCounter;

        }
        public override string ToString()
        {
            return $"ID: {TransactionId}, amount :{Amount},date :{Date},transactiontype :{Type} ";
        }

        #endregion

    }
}
