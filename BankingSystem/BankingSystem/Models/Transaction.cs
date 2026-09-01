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
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public Account? Account { get; set; }
        #endregion

        #region ctors


        public Transaction(decimal amount, TransactionType type, Account? account)
        {
            TransactionId = GetNewTransactionId();
            Amount = amount;
            Date = DateTime.Now;
            Type = type;
            Account = account;
        }
        #endregion

        #region methods 
        public int GetNewTransactionId()
        {
            idTransactionCounter++;
            return idTransactionCounter;

        }
        public override string ToString()
        {
            return $"ID: {TransactionId}, amount :{Amount},date :{Date},transactiontype :{Type} ";
        }

        #endregion

    }
}
