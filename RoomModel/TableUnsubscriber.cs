using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class TableUnsubscriber : IDisposable
    {

        private List<IObserver<ITable>> _observers;
        private IObserver<ITable> _observer;

        public TableUnsubscriber(List<IObserver<ITable>> observers, IObserver<ITable> observer)
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
