using System.Linq;
using LNL.MvpSpecFlow.Contracts;
using LNL.MvpSpecFlow.Models;
using LNL.MvpSpecFlow.Web.Presenters;
using Moq;
using NUnit.Framework;

namespace Demo.Web.Tests
{
    [TestFixture]
    public class PrimeNumbersPresenterTest
    {
        private Mock<IPrimeNumbersView> _mockView;
        private Mock<IPrimeNumberGenerator> _mockManager;
        private PrimeNumbersPresenter _sut;

        [SetUp]
        public void Setup()
        {
            _mockView = new Mock<IPrimeNumbersView>();
            _mockManager = new Mock<IPrimeNumberGenerator>();
            _sut = new PrimeNumbersPresenter(_mockView.Object, _mockManager.Object);
        }

        [Test]
        public void SaveEntity_WhenCalled_CallsIsPrimeManager()
        {
            const int someNumber = 7;
            const bool isPrime = true;
            var someEntityModel = new PrimeNumbersModel { Number = someNumber };
            _mockManager.Setup(x => x.IsPrime(someNumber)).Returns(isPrime);
            _mockView.Setup(x => x.Model).Returns(someEntityModel);

            _sut.SaveEntity();

            _mockManager.Verify(x => x.IsPrime(It.IsAny<int>()), Times.Once);
            Assert.IsTrue(someEntityModel.IsPrime);

        }

        [Test]
        public void CalculatePrimes_WhenCalled_CallsIsPrimeManager()
        {
            const int someNumber = 3;
            const bool isPrime = true;
            var someEntityModel = new PrimeNumbersModel { Number = someNumber };
            _mockManager.Setup(x => x.IsPrime(It.IsAny<int>())).Returns(isPrime).Verifiable();
            _mockView.Setup(x => x.Model).Returns(someEntityModel);

            _sut.CalculatePrimes();

            _mockManager.Verify(x => x.IsPrime(It.IsAny<int>()), Times.Exactly(4));
            Assert.IsTrue(someEntityModel.PrimesCollection.All(x => x.Value));
        }
    }
}
