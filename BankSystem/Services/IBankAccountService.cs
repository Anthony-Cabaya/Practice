namespace BankSystem.Services
{
    public interface IBankAccountService
    {
        ServiceResult Deposit(decimal amount);
        ServiceResult Withdraw(decimal amount);
        decimal ViewBalance();
    }
}
