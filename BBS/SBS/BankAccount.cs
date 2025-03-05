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
    }

    class BankAccount
    {
        protected static SortedDictionary<int, Account> UserInfo = new SortedDictionary<int, Account>();
        public void Deposit(int accountNumber, decimal amount)
        {
            try
            {
                UserInfo[accountNumber].Balance += amount;
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
    }
}
