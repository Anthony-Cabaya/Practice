namespace BankSystem.Entities
{
    public class PersonalAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }
    }
}
