using System.Collections.Generic;

namespace LNL.MvpSpecFlow.Models
{
    public class PrimeNumbersModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int Number { get; set; } 
        public bool IsEnabled { get; set; }
        public bool IsPrime { get; set; }
        public Dictionary<int, bool> PrimesCollection { get; set; } 
    }
}