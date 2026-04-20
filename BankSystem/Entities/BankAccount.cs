namespace BankSystem.Entities
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public BankAccount(string accountOwner)
        {
            Name = accountOwner;
            Balance = 0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public virtual bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= 0;
        }
        public virtual string GetWithdrawErrorMessage()
        {
            return "Insufficient balance.";
        }
    }
}
