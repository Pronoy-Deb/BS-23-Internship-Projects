//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Security.Cryptography.X509Certificates;
using BBS;

BankAccount Bank = new BankAccount();
RegularAccount Regular = new RegularAccount();
SavingsAccount Savings = new SavingsAccount();

while (true)
{
    Console.WriteLine("Simple Banking System\n" +
        "1. Create Account\n" +
        "2. Deposit\n" +
        "3. Withdraw\n" +
        "4. Check Balance\n" +
        "5. Apply Interest (Savings Account)\n" +
        "6. Exit");
    Console.Write("Choose an option: ");
    int Option = Convert.ToInt32(Console.ReadLine());
    switch (Option)
    {
        case 1:
            CreateAccount();
            break;
        case 2:
            Deposit();
            break;
        case 3:
            Withdraw();
            break;
        case 4:
            CheckBalance();
            break;
        case 5:
            ApplyInterest();
            break;
        case 6:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    void CreateAccount()
    {
        Console.Write("Enter account type (1 - Regular, 2 - Savings): ");
        int Type = Convert.ToInt32(Console.ReadLine());
        if (Type == 1)
        {
            Regular.TakeInfo();
        }
        else if (Type == 2)
        {
            Savings.TakeInfo();
        }
        else
        {
            throw new Exception("Invalid account type. Please try again.");
        }
    }

    void Deposit()
    {
        Console.Write("Enter the Account Number: ");
        int AccountNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the Amount to Deposit: ");
        decimal Amount = Convert.ToDecimal(Console.ReadLine());
        Bank.Deposit(AccountNumber, Amount);
    }

    void Withdraw()
    {
        Console.Write("Enter the Account Number: ");
        int AccountNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the Amount to Withdraw: ");
        decimal Amount = Convert.ToDecimal(Console.ReadLine());
        Bank.Withdraw(AccountNumber, Amount);
    }

    void CheckBalance()
    {
        Console.Write("Enter the Account Number: ");
        int AccountNumber = Convert.ToInt32(Console.ReadLine());
        Bank.CheckBalance(AccountNumber);
    }

    void ApplyInterest()
    {
        Console.Write("Enter the Account Number: ");
        int AccountNumber = Convert.ToInt32(Console.ReadLine());
        Savings.ApplyInterest(AccountNumber);
    }
}