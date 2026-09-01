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
        public bool AddCustomer(string? id, string? name, string? phone, string? email)
        {
            if (string.IsNullOrWhiteSpace(id) || SearchCustomer(id))
                return false;

            Customer customer = new Customer(id, name, phone, email);
            Customers.Add(customer);
            return true;

        }

        public bool SearchCustomer(string? customerId)
        {
            if(customerId is null)return false;
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
                foreach (Account account in customer.Accounts)
                {
                    Accounts.Remove(account);
                }
                customer.Accounts.Clear();
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

        public bool AddAccount(AccountType accountType, Customer customer)
        {
            if (customer is null || !SearchCustomer(customer.Id)) return false;
            if (accountType == AccountType.Saving)
            {
                SavingsAccount savingsAccount = new SavingsAccount(GetNewAccountNumber(), customer);
                Accounts.Add(savingsAccount);
                customer.Accounts.Add(savingsAccount);
                return true;

            }
            else if (accountType == AccountType.Current)
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
            if (SearchAccount(account.AccountNumber) && customer.Accounts.Contains(account))
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
