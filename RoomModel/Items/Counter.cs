using System;
using Shared;
using System.Collections.Generic;

namespace Model {
    public class Counter : ICounter
    {
        private int OrderNb;
        private int Size;
        private List<IOrder> Orders;

        public List<IObserver<IOrder>> observers;

        public Counter(int size)
        {
            this.OrderNb = 0;
            this.Size = size;
            this.Orders = new List<IOrder>();
            this.observers = new List<IObserver<IOrder>>();
        }

        public void AddOrder(IOrder newOrder)
        {
            lock (Orders)
            {
                newOrder.OrderNum = ++OrderNb;
                Orders.Add(newOrder);
            }

            // TO DELETE WHEN KITCHEN IMPLEMENTED
            OrderPrepared(OrderNb);

        }

        public void OrderPrepared(int OrderNum)
        {
            lock (Orders)
            {
                foreach (IOrder order in Orders)
                {
                    if (order.OrderNum == OrderNum)
                    {
                        Onchange(order);
                        break;
                    }
                }
            }
        }

        public IDisposable Subscribe(IObserver<IOrder> observer)
        {
                if (! observers.Contains(observer))
                observers.Add(observer) ;

            return new CounterUnsubscriber(observers, observer);
        }

        public void RemoveOrder(IOrder order)
        {
            lock (Orders)
            {
                if (Orders.Contains(order))
                {
                    Orders.Remove(order);
                }
            }
        }


        public void Onchange(IOrder order)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(order);
            }
        }

    }
}