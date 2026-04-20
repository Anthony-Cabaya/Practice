using BankSystem.Entities;
using BankSystem.Repositories;

namespace BankSystem.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IAccountRepository _repository;

        public BankAccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public ServiceResult Deposit(int id, decimal amount)
        {
            var account = _repository.GetById(id);

            if (account == null)
                return ServiceResult.Fail("Account not found.");

            if (amount <= 0)
                return ServiceResult.Fail("Invalid amount. Deposit must be greater than 0.");

            account.Balance += amount;
            account.UpdatedDate = DateTime.Now;

            return ServiceResult.Ok($"Successfully deposited: {amount:F2}", account.Balance);
        }

        public ServiceResult Withdraw(int id, decimal amount)
        {
            var account = _repository.GetById(id);

            if (account == null)
                return ServiceResult.Fail("Account not found.");

            if (amount <= 0)
                return ServiceResult.Fail("Invalid amount. Withdrawal must be greater than 0.");

            if (!account.CanWithdraw(amount))
                return ServiceResult.Fail(account.GetWithdrawErrorMessage());

            account.Balance -= amount;
            account.UpdatedDate = DateTime.Now;
            return ServiceResult.Ok($"Successfully withdrew: {amount:F2}", account.Balance);
        }

        public ServiceResult ViewBalance(int id)
        {
            var account = _repository.GetById(id);

            if (account == null)
                return ServiceResult.Fail("Account not found.");

            return ServiceResult.Ok("Balance retrieved.", account.Balance);
        }

        public BankAccount CreateAccount(BankAccount account)
        {
            return _repository.Add(account);
        }
    }
}
