using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Models
{
    internal class Customer
    {
       
        #region Properties
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<Account> Accounts { get; set; }=new List<Account>();
        #endregion

        #region ctors
        public Customer(string? id, string? name, string? phone, string? email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }
        #endregion
        #region methods
        public override string ToString()
        {
            return $"customer id :{Id} , name :{Name} , phone :{Phone}, email :{Email}";
        }
        #endregion

    }
}
