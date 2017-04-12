using System;
using System.Linq;
using LNL.MvpSpecFlow.Contracts;
using LNL.MvpSpecFlow.Models;
using LNL.MvpSpecFlow.Web.Presenters;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LNL.MvpSpecFlow.Web.IntegrationTests
{
    [Binding]
    public class PrimeNumbersViewFixture : IPrimeNumbersView
    {
        public event Action OnSave;
        public event Action LoadData;
        public event Action CalculatePrimes;
        public PrimeNumbersModel Model { get; set; }

        public PrimeNumbersViewFixture()
        {
            new PrimeNumbersPresenter(this);

            if (LoadData != null)
                LoadData();
        }

        [Given(@"I have entered (.*) into the Number field")]
        public void GivenIHaveEnteredIntoTheNumberField(int p0)
        {
            Model.Number = p0;
        }
        
        [Given(@"I have entered '(.*)' into the Name field")]
        public void GivenIHaveEnteredIntoTheNameField(string p0)
        {
            Model.Name = p0;
        }
        
        [When(@"I press save")]
        public void WhenIPressSave()
        {
            if (OnSave != null)
                OnSave();
        }

        [When(@"I press calculate")]
        public void WhenIPressCalculate()
        {
            if (CalculatePrimes != null)
                CalculatePrimes();
        }
        
        [Then(@"the id should be greater then (.*) on the screen")]
        public void ThenTheIdShouldBeGreaterThenOnTheScreen(int p0)
        {
            Assert.Greater(Model.Id, 0);
        }
        
        [Then(@"the name should be '(.*)'")]
        public void ThenTheNameShouldBe(string p0)
        {
            Assert.AreEqual(p0, Model.Name);
        }

        [Then(@"number should be found prime")]
        public void ThenTheNumberShouldBeFoundPrime()
        {
            Assert.IsTrue(Model.IsPrime);
        }

        [Then(@"number should be found non prime")]
        public void ThenTheNumberShouldBeFoundNonPrime()
        {
            Assert.IsFalse(Model.IsPrime);
        }

        [Then(@"output numbers should be:")]
        public void ThenThePrimesOutputShouldBe(Table data)
        {
            var values = data.CreateSet<PrimeNumberRecord>();
            Assert.AreEqual(values.Count(), Model.PrimesCollection.Keys.Count);
            foreach (var number in values)
            {
                Assert.AreEqual(number.IsPrime, Model.PrimesCollection[number.Number]);
            }
        }

        private class PrimeNumberRecord
        {
            public int Number { get; set; }
            public bool IsPrime { get; set; }
        }
    }
}
