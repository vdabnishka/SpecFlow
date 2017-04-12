using System.Collections.Generic;
using LNL.MvpSpecFlow.Domain;
using LNL.MvpSpecFlow.Contracts;
using LNL.MvpSpecFlow.Models;

namespace LNL.MvpSpecFlow.Web.Presenters
{
    public class PrimeNumbersPresenter
    {
        private readonly IPrimeNumbersView _view;
        private readonly IPrimeNumberGenerator _generator;

        /// <summary>
        /// Persistance Storage "Emulator"
        /// </summary>
        private static PrimeNumbersModel _storage;
        static PrimeNumbersPresenter()
        {
            _storage = _storage ?? new PrimeNumbersModel
            {
                IsEnabled = true,
                Name = "some name",
                Id = 0,
                PrimesCollection = new Dictionary<int, bool>()
            };
        }

        public PrimeNumbersPresenter(IPrimeNumbersView view) : this(view, new PrimeNumberGenerator())
        {
            
        }

        public PrimeNumbersPresenter(IPrimeNumbersView view, IPrimeNumberGenerator generator)
        {
            _view = view;
            _generator = generator;
            view.OnSave += SaveEntity;
            view.LoadData += LoadData;
            view.CalculatePrimes += CalculatePrimes;
        }

        public void CalculatePrimes()
        {
            _view.Model.PrimesCollection = new Dictionary<int, bool>();
            var number = _view.Model.Number;
            for (var i = 1; i <= number; i++)
            {
                _view.Model.PrimesCollection.Add(i, _generator.IsPrime(i));
            }

            SaveEntity();
        }

        private void LoadData()
        {
            _view.Model = _storage;
        }

        public void SaveEntity()
        {
            _view.Model.Id++;
            _view.Model.IsPrime = _generator.IsPrime(_view.Model.Number);

            _storage = _view.Model;
        }
    }
}