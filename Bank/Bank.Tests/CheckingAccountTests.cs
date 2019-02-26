using NUnit.Framework;

namespace Bank.Tests
{
    [TestFixture]
    public class CheckingAccountTests
    {
        private CheckingAccount _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CheckingAccount("Bert", 0.05);
        }

        [TearDown] //not really necessary here. Left here to show usage of TearDown
        public void TearDown()
        {
            _sut = null;
        }

        [Test]
        public void ShouldHave0BalanceAfterConstructor()
        {
            //Assert
            Assert.That(_sut.Balance, Is.EqualTo(0.0));
        }

        [TestCase(100, 50)]
        [TestCase(-150, 50)]
        [TestCase(20, 80)]
        [TestCase(50, 0)]
        public void ShouldHaveLessBalanceAfterWithdraw(double startingBalance, double amount)
        {
            //Arrange
            _sut = new CheckingAccount("Bert", 0.05, startingBalance);

            //Act
            _sut.Withdraw(amount);

            //Assert
            Assert.That(_sut.Balance, Is.EqualTo(startingBalance - amount));
        }

        [Test]
        public void ShouldNotBeAbleToWithdrawNegativeNumber()
        {
            //Arrange -> See setup

            //Act + Assert
            Assert.That(() => _sut.Withdraw(-10), Throws.Exception);
        }


        [TestCase(100, 50)]
        [TestCase(-150, 50)]
        [TestCase(20, 80)]
        [TestCase(50, 0)]
        public void ShouldHaveIncreasedBalanceAfterDeposit(double startingBalance, double amount)
        {
            //Arrange
            _sut = new CheckingAccount("Bert", 0.05, startingBalance);

            //Act
            _sut.Deposit(amount);

            //Assset
            Assert.That(_sut.Balance, Is.EqualTo(startingBalance + amount));
        }

        [Test]
        public void ShouldNotBeAbleToDepositNegativeNumber()
        {
            //Arrange -> See setup

            //Act + Assert
            Assert.That(() => _sut.Deposit(-10), Throws.Exception);
        }

        [Test]
        public void ShouldHaveNegativeInterestIfBalanceIsNegative()
        {
            //Arrange -> See setup

            //Act
            _sut.Withdraw(100);

            //Assert
            Assert.That(_sut.InterestRate, Is.LessThan(0));
        }

        [Test]
        public void ShouldHaveNegativeInterestRateIfStartingWithNegativeBalance()
        {
            //Act
            _sut = new CheckingAccount("Bert", 0.05, -200);

            //Assert
            Assert.That(_sut.InterestRate, Is.LessThan(0));
        }

        [Test]
        public void ShouldIncreaseBalanceAfterPositiveInterest()
        {
            //Arrange
            _sut = new CheckingAccount("Bert", 0.05, 100);
            double orginalBalance = _sut.Balance;

            //Act
            _sut.AddInterests();

            //Assert
            Assert.That(_sut.Balance, Is.GreaterThan(orginalBalance));
        }


        [Test]
        public void ShouldIncludeOwnerInToString()
        {
            //Arrange -> See setup

            //Act
            string accountAsText = _sut.ToString();

            //Assert
            Assert.That(accountAsText, Contains.Substring(_sut.Owner));
        }

        [Test]
        public void ShouldIncludeBalanceInToString()
        {
            //Arrange -> See setup

            //Act
            string accountAsText = _sut.ToString();

            //Assert
            Assert.That(accountAsText, Contains.Substring("" + _sut.Balance));
        }
    }
}
