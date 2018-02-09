using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Thread5
{
    class Program
    {
        //private static List<int> _firstList = new List<int>();

        private static List<int> _array = new List<int>();

        public static List<int> FirstList
        {
            get
            {
                return _array;
            }
            set
            {
                _array = value;
            }
        }

        private static void FirstPrimeList()
        {
            for (int i = 0; i < Math.Sqrt(_array.Count); i++)
            {
                if (StaticHelper.IsPrimeNumber(_array[i]))
                {
                    for (int j = i + 1; j < _array.Count; j++)
                    {
                        if (_array[j] != i && _array[j] % _array[i] == 0)
                            _array.RemoveAt(j);
                    }
                }
            }
        }

        private static void GetArray(int length)
        {
            for (int i = 2; i < length; i++)
            {
                _array.Add(i);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter to length vector: ");
            int length = StaticHelper.GetInt(Console.ReadLine());
            GetArray(length);
            FirstPrimeList();

            Console.Write("Please enter to number of threads: ");
            int numberOfThreads = StaticHelper.GetInt(Console.ReadLine());

            MyThread[] threads = new MyThread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new MyThread(numberOfThreads, i, _array[i]);
            }

            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i].Join();
            }

            foreach (var My in _array)
            {
                Console.Write(My + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
        }
    }
}
