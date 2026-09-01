using BankingSystem.Models;

namespace BankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.AddCustomer("30502232412", "ebrahim"," 01222659195", "azazhima@gmail.com");
            bank.AddCustomer("30502232412", "ahmed", " 01452659195", "azazahmed@gmail.com");
            Customer customer01 = new Customer("3050323","hima","0122324","fsdfdsf");
            foreach (var item in bank.Customers)
            {
                Console.WriteLine(item);
            }
           

            foreach (var item in bank.Accounts)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(bank.Customers[0].Accounts.Count);
            //Console.WriteLine(bank.Accounts.Count);
            Customer customer = bank.Customers[0];

            bank.AddAccount("SavingAccount", customer);
            bank.AddAccount("CurrentAccount", customer);

            Account saving = customer.Accounts[0];
            Account current = customer.Accounts[1];

            Console.WriteLine(saving.Deposit(1000));
            saving.ShowBalance();

            Console.WriteLine(saving.Withdraw(300));
            saving.ShowBalance();
            saving.Withdraw(300);

            Console.WriteLine(current.Withdraw(300));
            current.ShowBalance();
            Console.WriteLine(current.Withdraw(300));
            current.ShowBalance();
            Console.WriteLine("-----------------");
            saving.ShowBalance();
            current.ShowBalance();

            Console.WriteLine(saving.Transfer(200, current));

            saving.ShowBalance();
            current.ShowBalance();
            foreach (var transaction in saving.Transactions)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine(bank.SearchCustomer("30502232412"));
            Console.WriteLine(bank.SearchCustomer("999999"));
            Console.WriteLine(bank.SearchAccount(saving.AccountNumber));
            Console.WriteLine(bank.SearchAccount(9999));
            Console.WriteLine(bank.Accounts.Count);
            Console.WriteLine(customer.Accounts.Count);
            Console.WriteLine(bank.RemoveAccount(customer, saving));

            Console.WriteLine(bank.Accounts.Count);
            Console.WriteLine(customer.Accounts.Count);
            Console.WriteLine(bank.RemoveCustomer(customer));
            Console.WriteLine(bank.Customers.Count);
            Console.WriteLine(bank.Accounts.Count);
        }
    }
}
