namespace BankSystem.Entities
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual bool CanWithdraw(decimal amount)
        {
            return Balance - amount >= 0;
        }
    }
}
