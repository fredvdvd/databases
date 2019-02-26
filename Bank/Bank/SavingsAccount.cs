using System;

namespace Bank
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string owner, double interestRate, double startingBalance = 0) : base(owner, interestRate, startingBalance)
        {
        }

        public override void Withdraw(double amount)
        {
            if (_balance < 0)
            {
                throw new System.Exception("balance below 0");
            }
            _balance -= amount;
        }

        public override void AddInterests()
        {
            _balance += _balance * _interestRate;
        }

        public override string ToString()
        {
            return Owner + " has " + _balance.ToString();
        }
    }
}
