using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS
{
    class SavingsAccount : BankAccount
    {
        public void TakeInfo()
        {
            Console.Write("Enter Account Number: ");
            int AccountNumber = Convert.ToInt32(Console.ReadLine());
            //bool AlreadyExists = Existence(AccountNumber);
            if (UserInfo.ContainsKey(AccountNumber))
            {
                throw new Exception("Account already exists!");
            }
            else
            {
                Account acc = new Account();
                Console.Write("Enter account Holder Name: ");
                acc.Name = Console.ReadLine();
                Console.Write("Enter Initial Balance: ");
                acc.Balance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Interest Rate (%): ");
                acc.InterestRate = Convert.ToDouble(Console.ReadLine());
                UserInfo.Add(AccountNumber, acc);
                Console.WriteLine("Savings Account Created Sucessfully!\n");
            }
        }

        public void ApplyInterest(int AccountNumber)
        {
            try
            {
                UserInfo[AccountNumber].Balance += UserInfo[AccountNumber].Balance * (decimal)UserInfo[AccountNumber].InterestRate / 100;
                Console.WriteLine("Interest applied successfully!");
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
