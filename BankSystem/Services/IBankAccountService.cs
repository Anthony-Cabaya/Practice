using BankSystem.Entities;

namespace BankSystem.Services
{
    public interface IBankAccountService
    {
        ServiceResult Deposit(int id, decimal amount);
        ServiceResult Withdraw(int id, decimal amount);
        ServiceResult ViewBalance(int id);
        BankAccount CreateAccount(BankAccount account);
    }
}
