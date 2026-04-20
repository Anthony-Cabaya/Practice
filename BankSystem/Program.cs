using BankSystem.Entities;
using BankSystem.Services;
using BankSystem.UI;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to BankSystem ===");

        // 1. Ask for name FIRST
        string name;

        while (true)
        {
            Console.Write("Enter account holder name: ");
            name = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(name))
                break;

            Console.WriteLine("Name cannot be empty.");
        }

        BankAccount? account = null;

        // 2. Choose account type
        while (account == null)
        {
            Console.WriteLine("\nSelect account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Debit Account");
            Console.WriteLine("3. Personal Account");
            Console.Write("Choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    account = new SavingsAccount(name);
                    break;

                case "2":
                    account = new DebitAccount(name);
                    break;

                case "3":
                    account = new PersonalAccount(name);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        account.CreatedDate = DateTime.Now;
        account.UpdatedDate = DateTime.Now;

        IBankAccountService service = new BankAccountService(account);
        ConsoleUI ui = new ConsoleUI(service);

        ui.Run();
    }
}