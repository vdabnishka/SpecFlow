using LNL.MvpSpecFlow.Contracts;

namespace LNL.MvpSpecFlow.Domain
{
    public class PrimeNumberGenerator : IPrimeNumberGenerator
    {
        public bool IsPrime(int number)
        {
            if (number == 1 || number == 0)
                return false;

            var i = 2;
            while (i < number)
            {
                if (number % i == 0)
                    return false;

                i++;
            }

            return true;
        }
    }
}
