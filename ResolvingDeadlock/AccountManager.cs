using System;
using System.Threading;

namespace ResolvingDeadlock
{
    /// <summary>
    /// Account manager.
    /// </summary>
    public class AccountManager
    {
        /// <summary>
        /// From account.
        /// </summary>
        private readonly Account _fromAccount;

        /// <summary>
        /// To account.
        /// </summary>
        private readonly Account _toAccount;

        /// <summary>
        /// Amount to transfer.
        /// </summary>
        private readonly double _amountToTransfer;

        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amountToTransfer = amountToTransfer;
        }

        /// <summary>
        /// Transfer method.
        /// </summary>
        public void Transfer()
        {
            // Object to lock.
            object _lock1, _lock2;

            // If fromAccount is < toAccount.
            if (_fromAccount.ID < _toAccount.ID)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {((Account)_lock1).ID}");

            lock (_lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock1).ID}");

                Console.WriteLine($"{Thread.CurrentThread.Name} suspended for 1 second");

                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} back in action and trying to acquire lock on {((Account)_lock2).ID}");

                lock (_lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock2).ID}");

                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);

                    Console.WriteLine($"{Thread.CurrentThread.Name} Transfered {_amountToTransfer} from {_fromAccount.ID} to {_toAccount.ID}");
                }
            }
        }
    }
}