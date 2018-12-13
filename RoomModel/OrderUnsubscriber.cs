using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Model
{
    class OrderUnsubscriber : IDisposable
    {

        private List<IObserver<IOrder>> _observers;
        private IObserver<IOrder> _observer;

        public OrderUnsubscriber(List<IObserver<IOrder>> observers, IObserver<IOrder> observer)
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