using BankSystem.Entities;

namespace BankSystem.Services
{
    public class BankAccountService : IBankAccountService
    {
        public readonly BankAccount _account;

        public BankAccountService(BankAccount account)
        {
            _account = account;
        }

        public ServiceResult Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal ViewBalance()
        {
            throw new NotImplementedException();
        }
    }
}
