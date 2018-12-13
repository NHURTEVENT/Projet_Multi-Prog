using System;
using Shared;
using System.Collections.Generic;

namespace Model {
    public class Counter : ICounter
    {
        private int OrderNb;
        private int Size;
        private List<IOrder> Orders;

        public Counter(int size)
        {
            this.Size = size;
            this.Orders = new List<IOrder>();
            this.OrderNb = 1;
        }

        public void AddOrder(IOrder newOrder)
        {

        }

        public void OrderPrepared(int OrderNum)
        {
            
        }
    }
}