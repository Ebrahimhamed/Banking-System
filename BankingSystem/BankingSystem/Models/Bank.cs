using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BankingSystem.Models
{
    internal class Bank
    {
        #region attributes
        private int idaccountcounter = 0;
        #endregion
        #region properties
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        #endregion
        #region methods
        public void AddCustomer(string? id, string? name, string? phone, string? email)
        {
            Customer customer = new Customer(id, name, phone, email);
            Customers.Add(customer);
        }

        public bool SearchCustomer(string? customerId)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.Id == customerId) return true;
            }
            return false;
        }
        public bool RemoveCustomer(Customer customer)
        {
            if (customer is null) return false;
            if (SearchCustomer(customer.Id))
            {
                foreach(Account account in customer.Accounts)
                {
                    Accounts.Remove(account);
                }
                Customers.Remove(customer);

                return true;
            }
            return false;
        }
        public int GetNewAccountNumber()
        {
            idaccountcounter++;
            return idaccountcounter;
        }

        public bool AddAccount(string accounttype, Customer customer)
        {
            if (customer is null) return false;
            if (accounttype == "SavingAccount")
            {
                SavingsAccount savingsAccount = new SavingsAccount(GetNewAccountNumber(), customer);
                Accounts.Add(savingsAccount);
                customer.Accounts.Add(savingsAccount);
                return true;

            }
            else if (accounttype == "CurrentAccount")
            {
                CurrentAccount currentAccount = new CurrentAccount(GetNewAccountNumber(), customer);
                Accounts.Add(currentAccount);
                customer.Accounts.Add(currentAccount);
                return true;
            }
            else return false;
        }

        public bool SearchAccount(int accountnumber)
        {
            foreach (Account account in Accounts)
            {
                if (account.AccountNumber == accountnumber) return true;
            }
            return false;
        }
        public bool RemoveAccount(Customer customer, Account account)
        {
            if (account is null || customer is null) return false;
            if (SearchAccount(account.AccountNumber))
            {
                customer.Accounts.Remove(account);
                Accounts.Remove(account);
                return true;
            }
            return false;
        }



        #endregion
    }
}
