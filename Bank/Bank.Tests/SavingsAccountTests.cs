using NUnit.Framework;

namespace Bank.Tests
{
    [TestFixture]
    public class SavingsAccountTests
    {
        private SavingsAccount _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SavingsAccount("Mieke", 0.10);
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }

        [Test]
        public void ShouldHave0BalanceAfterConstructor()
        {
            //Arrange
            //Act
            //Assert
            Assert.That(_sut.Balance, Is.EqualTo(0.0));
        }

        [TestCase(100, 50)]
        [TestCase(80, 20)]
        [TestCase(50, 0)]
        [TestCase(0, 0)]
        public void ShouldHaveLessBalanceAfterWithdraw(double startingBalance, double amount)
        {
            //Arrange
            _sut = new SavingsAccount("Mieke", 0.10, startingBalance);

            //Act
            _sut.Withdraw(amount);
            Assert.That(_sut.Balance, Is.LessThanOrEqualTo(startingBalance));
        }


        [Test]
        public void ShouldNotBeAbleToWithdrawNegativeNumber()
        {
            //Act
            Assert.That(() => _sut.Deposit(-10), Throws.Exception); 
        }

        [Test]
        public void ShouldNotBeAbleToStartWithNegativeBalance()
        {
            Assert.That(_sut.Balance, Is.GreaterThanOrEqualTo(0.0));
        }

        [Test]
        public void ShouldThrowExceptionIfWithdrawingToNegativeBalance()
        {
            _sut = new SavingsAccount("Mieke", 0.10, -1);
            Assert.That(() => _sut.Withdraw(10), Throws.Exception);
        }

        [TestCase(100, 50)]
        [TestCase(20, 80)]
        [TestCase(50, 0)]
        [TestCase(0, 10)]
        [TestCase(0, 0)]
        public void ShouldHaveIncreasedBalanceAfterDeposit(double startingbalance, double amount)
        {
            _sut = new SavingsAccount("Mieke", 0.10, startingbalance);
            _sut.Deposit(amount);
            Assert.That( _sut.Balance, Is.AtLeast (startingbalance));
        }

        [Test]
        public void ShouldNotBeAbleToDepositNegativeNumber()
        {
            Assert.That(() => _sut.Deposit(-10), Throws.Exception);
        }

        [TestCase(10)]
        public void ShouldIncreaseBalanceAfterPositiveInterest(double startingBalance)
        {
            _sut = new SavingsAccount("Mieke", 0.10, startingBalance);
            _sut.AddInterests();
            Assert.That(_sut.Balance, Is.GreaterThan(startingBalance));
        }


        [Test]
        public void ShouldIncludeOwnerInToString()
        {
            string ownerAsText = _sut.ToString();
            Assert.That(ownerAsText, Contains.Substring(_sut.Owner));
        }

        [Test]
        public void ShouldIncludeBalanceInToString()
        {
            string accountAsText = _sut.ToString();
            Assert.That(accountAsText, Contains.Substring("" + _sut.Balance));
        }
    }
}
