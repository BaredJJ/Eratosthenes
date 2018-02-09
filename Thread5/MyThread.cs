using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread5
{
    class MyThread
    {
        private readonly Thread _thread;

        private readonly object _locked = new object();

        private readonly int _step;

        private int _count;

        private int _currentPrimeNumber;

        private static bool _flag = false;

        //public static AutoResetEvent Reset { get; set; }

        //static MyThread()
        //{
        //    Reset = new AutoResetEvent(false);
        //}

        public MyThread(int step, int count, int currentPrimeNumber)
        {
            _step = step;
            _count = count;
            _currentPrimeNumber = currentPrimeNumber;
            //_locked = new object();

            _thread = new Thread(Run);
            _thread.Start();
        }

        /// <summary>
        /// Проверка от корня из n по n
        /// </summary>
        private void Run()
        {
            while (true)
            {
                //Reset.WaitOne();
                lock (_locked)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " value " + _currentPrimeNumber);
                    for (int i = (int) Math.Sqrt(Program.FirstList.Count); i < Program.FirstList.Count; i++)
                    {
                        
                        if (Program.FirstList[i] != _currentPrimeNumber && Program.FirstList[i] % _currentPrimeNumber == 0)
                            Program.FirstList.RemoveAt(i);
                    }

                    if (_currentPrimeNumber == Program.PrimeNumber[Program.PrimeNumber.Count - 1])
                        _flag = true;

                    this._currentPrimeNumber = Program.PrimeNumber[Math.Min(_count += _step, Program.PrimeNumber.Count - 1)];
                }
                //Reset.Set();
                if (_flag)
                    break;

            }

        }

        public void Join() => _thread.Join( );
    }
}
