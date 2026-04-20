namespace BankSystem.Entities
{
    public class SavingsAccount : BankAccount
    {
        private readonly decimal _minimumBalance = 500.00m;

        public override bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= _minimumBalance;
        }
    }
}
