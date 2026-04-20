using BankSystem.Entities;

namespace BankSystem.Repositories
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly List<BankAccount> _accounts = new List<BankAccount>();
        private int _nextId = 1;

        public BankAccount Add(BankAccount account)
        {
            account.Id = _nextId++;
            _accounts.Add(account);
            return account;
        }

        public BankAccount? GetById(int id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return _accounts;
        }
    }
}
