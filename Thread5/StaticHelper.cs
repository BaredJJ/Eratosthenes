using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread5
{
    static class StaticHelper
    {
        public static int GeneratePrimeNumber(int number)
        {
            for (int i = number + 1; i < int.MaxValue; i++)
            {
                if (IsPrimeNumber(i))
                    return i;
            }

            return 0;
        }

        public static bool IsPrimeNumber(int number)
        {
            for (int i = 2; i <= number / i; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static int GetInt<T>(T t)
        {
            int n;
            if(!int.TryParse(t.ToString(), out n))
                throw new FormatException("incorrect data type int");

            return n;
        }
    }
}
