﻿using System;
using System.Threading;

namespace ResolvingDeadlock
{
    public static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Main Started");
            Account accountA = new Account(101, "Account A", 5000);
            Account accountB = new Account(102, "Account B", 3000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            Thread T1 = new Thread(accountManagerA.Transfer)
            {
                Name = "Thread 1"
            };

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);
            Thread T2 = new Thread(accountManagerB.Transfer)
            {
                Name = "Thread 2"
            };

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();
            Console.WriteLine("Main Completed");
        }
    }
}