using BankingSystem.Models;

namespace BankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          E B R A H I M   B A N K");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Bank bank = new Bank();

            Console.WriteLine("===== Add Customers =====");

            Console.WriteLine(
                $"Add Ebrahim Hamed: {bank.AddCustomer(
                    "EB001",
                    "Ebrahim Hamed",
                    "01000000000",
                    "ebrahim@example.com"
                )}"
            );

            Console.WriteLine(
                $"Add Ahmed Ali: {bank.AddCustomer(
                    "AH002",
                    "Ahmed Ali",
                    "01111111111",
                    "ahmed@example.com"
                )}"
            );

            Console.WriteLine(
                $"Add duplicate ID: {bank.AddCustomer(
                    "EB001",
                    "Another Ebrahim",
                    "01222222222",
                    "another@example.com"
                )}"
            );

            Console.WriteLine(
                $"Add customer with empty ID: {bank.AddCustomer(
                    " ",
                    "Test User",
                    "01233333333",
                    "test@example.com"
                )}"
            );

            Console.WriteLine("\n===== Customers =====");

            foreach (Customer customer in bank.Customers)
            {
                Console.WriteLine(
                    $"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.Phone}, Email: {customer.Email}"
                );
            }

            Customer ebrahim = bank.Customers[0];
            Customer ahmed = bank.Customers[1];

            Console.WriteLine("\n===== Add Accounts =====");

            Console.WriteLine(
                $"Add Saving Account for Ebrahim: {bank.AddAccount(AccountType.Saving, ebrahim)}"
            );

            Console.WriteLine(
                $"Add Current Account for Ebrahim: {bank.AddAccount(AccountType.Current, ebrahim)}"
            );

            Console.WriteLine(
                $"Add Saving Account for Ahmed: {bank.AddAccount(AccountType.Saving, ahmed)}"
            );

            Console.WriteLine("\n===== Accounts =====");

            foreach (Account account in bank.Accounts)
            {
                Console.WriteLine(account);
            }

            Account saving = ebrahim.Accounts[0];
            Account current = ebrahim.Accounts[1];

            Console.WriteLine("\n===== Deposit =====");

            Console.WriteLine(
                $"Deposit 1000 into Ebrahim's Saving Account: {saving.Deposit(1000)}"
            );

            Console.WriteLine($"Saving Balance: {saving.Balance}");

            Console.WriteLine(
                $"Deposit -100: {saving.Deposit(-100)}"
            );

            Console.WriteLine($"Saving Balance: {saving.Balance}");

            Console.WriteLine("\n===== Saving Withdraw =====");

            Console.WriteLine(
                $"Withdraw 300: {saving.Withdraw(300)}"
            );

            Console.WriteLine($"Saving Balance: {saving.Balance}");

            Console.WriteLine(
                $"Withdraw 1000: {saving.Withdraw(1000)}"
            );

            Console.WriteLine($"Saving Balance: {saving.Balance}");

            Console.WriteLine("\n===== Current Account =====");

            Console.WriteLine(
                $"Withdraw 300: {current.Withdraw(300)}"
            );

            Console.WriteLine($"Current Balance: {current.Balance}");

            Console.WriteLine(
                $"Withdraw 300 again: {current.Withdraw(300)}"
            );

            Console.WriteLine($"Current Balance: {current.Balance}");

            Console.WriteLine("\n===== Transfer =====");

            Console.WriteLine($"Saving Balance Before Transfer: {saving.Balance}");
            Console.WriteLine($"Current Balance Before Transfer: {current.Balance}");

            Console.WriteLine(
                $"Transfer 200 from Saving to Current: {saving.Transfer(200, current)}"
            );

            Console.WriteLine($"Saving Balance After Transfer: {saving.Balance}");
            Console.WriteLine($"Current Balance After Transfer: {current.Balance}");

            Console.WriteLine("\n===== Search =====");

            Console.WriteLine(
                $"Search Ebrahim: {bank.SearchCustomer("EB001")}"
            );

            Console.WriteLine(
                $"Search unknown customer: {bank.SearchCustomer("XX999")}"
            );

            Console.WriteLine(
                $"Search Saving Account: {bank.SearchAccount(saving.AccountNumber)}"
            );

            Console.WriteLine(
                $"Search Account 999: {bank.SearchAccount(999)}"
            );

            Console.WriteLine("\n===== Transactions =====");

            Console.WriteLine("Ebrahim Saving Transactions:");

            foreach (Transaction transaction in saving.Transactions)
            {
                Console.WriteLine(transaction);
                Console.WriteLine(
                    $"From: {transaction.FromAccount?.AccountNumber}"
                );
                Console.WriteLine(
                    $"To: {transaction.ToAccount?.AccountNumber}"
                );
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("\nEbrahim Current Transactions:");

            foreach (Transaction transaction in current.Transactions)
            {
                Console.WriteLine(transaction);
                Console.WriteLine(
                    $"From: {transaction.FromAccount?.AccountNumber}"
                );
                Console.WriteLine(
                    $"To: {transaction.ToAccount?.AccountNumber}"
                );
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("\n===== Remove Account =====");

            Console.WriteLine(
                $"Remove Saving Account from Ahmed: {bank.RemoveAccount(ahmed, saving)}"
            );

            Console.WriteLine(
                $"Remove Saving Account from Ebrahim: {bank.RemoveAccount(ebrahim, saving)}"
            );

            Console.WriteLine($"Bank Accounts Count: {bank.Accounts.Count}");
            Console.WriteLine($"Ebrahim Accounts Count: {ebrahim.Accounts.Count}");

            Console.WriteLine("\n===== Remove Customer =====");

            Console.WriteLine(
                $"Remove Ahmed: {bank.RemoveCustomer(ahmed)}"
            );

            Console.WriteLine($"Customers Count: {bank.Customers.Count}");
            Console.WriteLine($"Accounts Count: {bank.Accounts.Count}");

            Console.WriteLine();
            Console.WriteLine("========================================");
            
        }
    }
}
