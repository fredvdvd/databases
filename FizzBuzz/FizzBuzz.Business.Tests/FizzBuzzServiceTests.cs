using System;
using NUnit.Framework;

namespace FizzBuzz.Business.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _service;

        
        [SetUp]
        public void Setup()
        {
            // Arrange step for ALL tests!
            _service = new FizzBuzzService();
        }

        [Test]
        [TestCase(2, 3, 1, "1")]
        public void ReturnsCorrectFizzBuzzTextWhenParametersAreValid(int fizzFactor, int buzzFactor, int lastNumber, string expected)
        {
            // Act

            // Assert
            Assert.Fail("Test not implemented yet");
        }

        public void ThrowsValidationExceptionWhenFizzFactorIsNotInRange(int fizzFactor)
        {
            //Act + Assert
            Assert.That(
                () => _service.GenerateFizzBuzzText(fizzFactor, FizzBuzzService.MinimumFactor, FizzBuzzService.MinimumLastNumber),
                Throws.InstanceOf<FizzBuzzValidationException>());
        }

        public void ThrowsValidationExceptionWhenBuzzFactorIsNotInRange(int buzzFactor)
        {
            Assert.Fail("Test not implemented yet");
        }

        public void ThrowsValidationExceptionWhenLastNumberIsNotInRange(int lastNumber)
        {
            Assert.Fail("Test not implemented yet");
        }
    }
}
