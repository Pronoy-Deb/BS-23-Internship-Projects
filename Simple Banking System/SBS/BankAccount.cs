using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS
{
    public class Account
    {
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }
        public int AccountType { get; set; }
    }

    class BankAccount
    {
        protected static SortedDictionary<int, Account> UserInfo = new SortedDictionary<int, Account>();
        public void Deposit(int accountNumber, decimal amount)
        {
            try
            {
                UserInfo[accountNumber].Balance += amount;
                Console.WriteLine("Deposited: " + amount + "\nNew Balance: " + UserInfo[accountNumber].Balance);
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
        }

        public void Withdraw(int accountNumber, decimal amount)
        {
            try
            {
                if (UserInfo[accountNumber].Balance >= amount)
                {
                    UserInfo[accountNumber].Balance -= amount;
                    Console.WriteLine("Withdrawal successful!");
                }
                else
                {
                    throw new Exception("Insufficient balance!");
                }
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
        }

        public void CheckBalance(int accountNumber)
        {
            try
            {
                Console.WriteLine("Account Holder Name: " + UserInfo[accountNumber].Name);
                Console.WriteLine("Account Balance: " + UserInfo[accountNumber].Balance);
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
        }
        
        public void Filter(int accountType)
        {
            Predicate<Account> type = (x) => x.AccountType == accountType;
            var filteredAccounts = UserInfo.Where(kv => type(kv.Value)).ToList();

            Console.WriteLine("Total " + (accountType == 1 ? "Regular" : "Savings") + " Accounts: " + filteredAccounts.Count);
            Console.WriteLine("Account Information:");
            
            foreach (var kv in filteredAccounts)
            {
                int accountNumber = kv.Key;
                Account acc = kv.Value;
                Console.WriteLine("Account Number: " + accountNumber);
                Console.WriteLine("Account Holder: " + acc.Name);
            }
        }

    }
}
