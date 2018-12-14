using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ICounter : IObservable<IOrder>
    {
        void AddOrder(IOrder order);
        void RemoveOrder(IOrder order);

    }
}
