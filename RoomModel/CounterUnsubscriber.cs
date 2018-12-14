using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Model
{
    public class CounterUnsubscriber : IDisposable
    {

        private List<IObserver<IOrder>> _observers;
        private IObserver<IOrder> _observer;

        public CounterUnsubscriber(List<IObserver<IOrder>> observers, IObserver<IOrder> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null))
            {
                _observers.Remove(_observer);
            }
        }
    }
}