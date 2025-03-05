using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBS
{
    class RegularAccount : BankAccount
    {
        public void TakeInfo()
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int AccountNumber = Convert.ToInt32(Console.ReadLine());
                if (UserInfo.ContainsKey(AccountNumber)) {
                    throw new Exception();
                }
                else
                {
                    Account acc = new Account();
                    Console.Write("Enter Account Holder Name: ");
                    acc.Name = Console.ReadLine();
                    Console.Write("Enter Initial Balance: ");
                    acc.Balance = Convert.ToDecimal(Console.ReadLine());
                    acc.InterestRate = 0.0;
                    acc.AccountType = 1;
                    UserInfo.Add(AccountNumber, acc);
                    Console.WriteLine("Regular Account Created Sucessfully!\n");
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
    }
}
