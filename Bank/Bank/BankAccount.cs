﻿using System;

namespace Bank
{
    //There are a few mistakes in this class. Can you figure out what those mistakes are?
    public abstract class BankAccount
    {
        protected double _interestRate;
        protected string _owner;
        protected double _balance ;

        protected BankAccount(string owner, double interestRate, double startingBalance) //startingBalance = 0
        {
            _owner = owner;
            _balance = startingBalance;
            _interestRate = interestRate;
        }

        public virtual double Balance
        {
            get {
                    return _balance;
                }
        }

        public virtual double InterestRate
        {
            get { return _interestRate; }
        }

        public virtual string Owner
        {
            get { return _owner; }
        }

        public abstract void Withdraw(double amount);

        public virtual void Deposit(double amount)
        {
            if(amount < 0)
            {
                throw new Exception("input below 0");
            }

            _balance += amount;
        }

        public virtual void AddInterests()
        {
            _balance += _balance * _interestRate;
        }

        public override string ToString()
        {
            return "Bankaccount as text";
        }
    }
}
