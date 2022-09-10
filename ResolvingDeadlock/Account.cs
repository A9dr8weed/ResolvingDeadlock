namespace ResolvingDeadlock
{
    /// <summary>
    /// Account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account Id.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Account description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Account balance.
        /// </summary>
        public double Balance { get; set; }

        public Account(int id, string description, double balance)
        {
            Id = id;
            Description = description;
            Balance = balance;
        }

        /// <summary>
        /// Withdraw money.
        /// </summary>
        /// <param name="amount"> Amount to withdraw. </param>
        public void Withdraw(double amount)
        {
            Balance -= amount;
        }

        /// <summary>
        /// Deposit money.
        /// </summary>
        /// <param name="amount"> Amount to deposit. </param>
        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}