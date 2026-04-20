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
            if (amount <= 0)
                return ServiceResult.Fail("Invalid amount. Deposit must be greater than 0.");

            _account.Balance += amount;
            _account.UpdatedDate = DateTime.Now;

            return ServiceResult.Ok($"Successfully deposited: ₱{amount.ToString("F2")}");
        }

        public ServiceResult Withdraw(decimal amount)
        {
            if (amount <= 0)
                return ServiceResult.Fail("Invalid amount. Deposit must be greater than 0.");

            if (!_account.CanWithdraw(amount))
                return ServiceResult.Fail("Invalid withdrawal amount.");

            _account.Balance -= amount;
            _account.UpdatedDate = DateTime.Now;
            return ServiceResult.Ok($"Successfully Withdraw: ₱{amount.ToString("F2")}");
        }

        public decimal ViewBalance()
        {
            return _account.Balance;
        }
    }
}
