using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread5
{
    class Program
    {
        private static List<int> _array = new List<int>();

        private static List<int> _primeNumber = new List<int>();

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

        public static List<int> PrimeNumber
        {
            get { return _primeNumber; }
            set { _primeNumber = value; }
        }

        private static void FirstPrimeList()
        {
            for (int i = 0; i < Math.Sqrt(_array.Count); i++)
            {
                if (StaticHelper.IsPrimeNumber(_array[i]))
                {
                    Program.PrimeNumber.Add(_array[i]);
                    for (int j = i + 1; j < Math.Sqrt(_array.Count); j++)
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

            //Console.Write("Please enter to number of threads: ");
            //int numberOfThreads = StaticHelper.GetInt(Console.ReadLine());

            //AutoResetEvent auto = new AutoResetEvent(false);
            //MyThread.Reset = auto;
            MyThread[] threads = new MyThread[Math.Min(8, Program.PrimeNumber.Count)];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new MyThread(threads.Length, i, Program.PrimeNumber[i]);
            }

            //auto.Set();
            for (int i = 0; i < threads.Length; i++)
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
