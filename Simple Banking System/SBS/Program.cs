using SBS;

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
        "6. Filter Accounts\n" +
        "7. Exit");
    Console.Write("Choose an option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
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
            Filter();
            break;
        case 7:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    void CreateAccount()
    {
        Console.Write("Enter account type (1 - Regular, 2 - Savings): ");
        int type = Convert.ToInt32(Console.ReadLine());
        if (type == 1)
        {
            Regular.TakeInfo();
        }
        else if (type == 2)
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
        int accountNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the Amount to Deposit: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Bank.Deposit(accountNumber, amount);
    }

    void Withdraw()
    {
        Console.Write("Enter the Account Number: ");
        int accountNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the Amount to Withdraw: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Bank.Withdraw(accountNumber, amount);
    }

    void CheckBalance()
    {
        Console.Write("Enter the Account Number: ");
        int accountNumber = Convert.ToInt32(Console.ReadLine());
        Bank.CheckBalance(accountNumber);
    }

    void ApplyInterest()
    {
        Console.Write("Enter the Account Number: ");
        int accountNumber = Convert.ToInt32(Console.ReadLine());
        Savings.ApplyInterest(accountNumber);
    }

    void Filter()
    {
        Console.WriteLine("1. Filter Regular Accounts\n" +
                      "2. Filter Savings Accounts");
        int filterType = Convert.ToInt32(Console.ReadLine());
        Bank.Filter(filterType);
    }
}