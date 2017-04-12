using System;
using LNL.MvpSpecFlow.Models;

namespace LNL.MvpSpecFlow.Contracts
{
    public interface IPrimeNumbersView
    {
        event Action OnSave;
        event Action LoadData;
        event Action CalculatePrimes;
        PrimeNumbersModel Model { get; set; }
    }
}
