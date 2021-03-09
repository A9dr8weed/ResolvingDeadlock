namespace ResolvingDeadlock
{
    /// <summary>
    /// Account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account balance.
        /// </summary>
        private double _balance;

        /// <summary>
        /// Account ID.
        /// </summary>
        private readonly int _id;

        public Account(int id, double balance)
        {
            _id = id;
            _balance = balance;
        }

        /// <summary>
        /// Public property.
        /// </summary>
        public int ID => _id;

        /// <summary>
        /// Withdraw money.
        /// </summary>
        /// <param name="amount"> Amount to withdraw. </param>
        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        /// <summary>
        /// Deposit money.
        /// </summary>
        /// <param name="amount"> Amount to deposit. </param>
        public void Deposit(double amount)
        {
            _balance += amount;
        }
    }
}