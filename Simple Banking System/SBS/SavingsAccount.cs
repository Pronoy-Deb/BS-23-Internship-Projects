using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS
{
    class SavingsAccount : BankAccount
    {
        public void TakeInfo()
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int AccountNumber = Convert.ToInt32(Console.ReadLine());
                if (UserInfo.ContainsKey(AccountNumber))
                {
                    throw new Exception();
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
                    acc.AccountType = 2;
                    UserInfo.Add(AccountNumber, acc);
                    Console.WriteLine("Savings Account Created Sucessfully!\n");
                }
            }
            catch (FormatException E)
            {
                Console.WriteLine(E.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Account already exists!");
            }
        }

        public void ApplyInterest(int AccountNumber)
        {
            try
            {
                if (UserInfo[AccountNumber].AccountType != 2)
                {
                    throw new Exception();
                }
                Func<decimal, decimal> Apply = (x) => x * (decimal)UserInfo[AccountNumber].InterestRate / 100;
                UserInfo[AccountNumber].Balance += Apply(UserInfo[AccountNumber].Balance);
                Console.WriteLine("Interest applied successfully!");
            }
            catch (KeyNotFoundException E)
            {
                Console.WriteLine(E.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Not a Savings Account!");
            }
        }
    }
}
