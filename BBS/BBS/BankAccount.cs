using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    public class Account
    {
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }
    }

    class BankAccount
    {
        public SortedDictionary<int, Account> UserInfo = new SortedDictionary<int, Account>();
        public bool Existence(int AccountNumber)
        {
            return UserInfo.ContainsKey(AccountNumber);
        }
        public void Deposit(int AccountNumber, decimal Amount)
        {
            try
            {
                UserInfo[AccountNumber].Balance += Amount;
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
        }

        public void Withdraw(int AccountNumber, decimal Amount)
        {
            try
            {
                if (UserInfo[AccountNumber].Balance >= Amount)
                {
                    UserInfo[AccountNumber].Balance -= Amount;
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

        public void CheckBalance(int AccountNumber)
        {
            try
            {
                Console.WriteLine("Account Holder Name: " + UserInfo[AccountNumber].Name);
                Console.WriteLine("Account Balance: " + UserInfo[AccountNumber].Balance);
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
