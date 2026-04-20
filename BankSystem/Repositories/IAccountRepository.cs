using BankSystem.Entities;

namespace BankSystem.Repositories
{
    public interface IAccountRepository
    {
        BankAccount Add(BankAccount account);
        BankAccount? GetById(int id);
        IEnumerable<BankAccount> GetAll();
    }
}
