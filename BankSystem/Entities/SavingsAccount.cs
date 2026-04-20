namespace BankSystem.Entities
{
    public class SavingsAccount : BankAccount
    {
        private readonly decimal _minimumBalance = 500.00m;
        public SavingsAccount(string accountOwner) : base(accountOwner) { }
        public override bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= _minimumBalance;
        }
        public override string GetWithdrawErrorMessage()
        {
            return $"Balance cannot go below ₱{_minimumBalance}";
        }
    }
}
