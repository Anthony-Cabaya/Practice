using BankSystem.Services;

namespace BankSystem.UI
{
    public class ConsoleUI
    {
        private readonly IBankAccountService _service;

        public ConsoleUI(IBankAccountService service)
        {
            _service = service;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Amount: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    var result = _service.Deposit(amount);
                    Console.WriteLine(result.Message);
                }
                else if (choice == "2")
                {
                    Console.Write("Amount: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    var result = _service.Withdraw(amount);
                    Console.WriteLine(result.Message);
                }
                else if (choice == "3")
                {
                    Console.WriteLine($"Balance: ₱{_service.ViewBalance():F2}");
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}