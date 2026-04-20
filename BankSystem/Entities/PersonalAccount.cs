namespace BankSystem.Entities
{
    public class PersonalAccount : BankAccount
    {
        private readonly decimal _overdraftLimit = 1000.00m;
        public override bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= -_overdraftLimit;
        }
        public override string GetWithdrawErrorMessage()
        {
            return $"Balance cannot go below ₱{_overdraftLimit}";
        }
    }
}
