namespace Bank
{
    //There are a few mistakes in this class
    //Figure out what those mistakes are using testing
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string owner, double interestRate, double startingBalance = 0) 
            : base(owner, interestRate, startingBalance) 
        {
            _balance = startingBalance; //fix
            if (_balance < 0)
            {
                _interestRate = -interestRate;
            }
            else
            {
                _interestRate = interestRate;
            }
        }

        public override void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new System.Exception("input below 0");
            }
            _balance -= amount;
            if (_balance < 0)
            {
                _interestRate = -_interestRate;
            }

        }

        public override string ToString()
        {
            return Owner + " has " + _balance.ToString();
        }
    }
}
