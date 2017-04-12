using LNL.MvpSpecFlow.Contracts;
using NUnit.Framework;

namespace LNL.MvpSpecFlow.Domain.Tests
{
    [TestFixture]
    public class PrimeNumberGeneratorTests
    {
        private IPrimeNumberGenerator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new PrimeNumberGenerator();
        }

        [Test]
        public void IsIntegerPrime_WhenGivenASeriesOfPrimes_ReturnsTrue()
        {
            var numbers = new[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29};

            foreach (var number in numbers)
            {
                Assert.IsTrue(_sut.IsPrime(number));
            }
        }

        [Test]
        public void IsIntegerPrime_WhenGivenASeriesOfNonPrimes_ReturnsFalse()
        {
            var numbers = new[] { 1, 4, 6, 8, 10 };

            foreach (var number in numbers)
            {
                Assert.IsFalse(_sut.IsPrime(number));
            }
        }
    }
}
