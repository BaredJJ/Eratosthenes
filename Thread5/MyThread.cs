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

        private readonly object _locker;

        private readonly int _step;

        private int _count;

        private int _currentPrimeNumber;        

        public MyThread(int step, int count, int currentPrimeNumber)
        {
            _step = step;
            _count = count;
            _currentPrimeNumber = currentPrimeNumber;
            _locker = new object();

            _thread = new Thread(Run);
            _thread.Start();
        }

        /// <summary>
        /// Проверка от корня из n по n
        /// </summary>
        private void Run()
        {
            lock (_locker)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " value " + _currentPrimeNumber);
                for (int i = (int)Math.Sqrt(Program.FirstList.Count); i < Program.FirstList.Count; i++)
                {
                    if (Program.FirstList[i] != i && Program.FirstList[i] % _currentPrimeNumber == 0)
                        Program.FirstList.RemoveAt(i);
                }

                this._currentPrimeNumber = Program.FirstList[Math.Min(_count + _step, Program.FirstList.Count - 1)];
            }
        }

        public void Join() => _thread.Join( );
    }
}
