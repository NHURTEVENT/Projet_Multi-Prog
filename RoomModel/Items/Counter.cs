using System;
using Shared;
using System.Collections.Generic;

namespace Model {
    public sealed class Counter : ICounter
    {
        private int OrderNb;
        private int Size;
        private List<IOrder> Orders;
        private  static Counter INSTANCE;

        private Counter()
        {
            this.Size = 15;
            this.Orders = new List<IOrder>();
            this.OrderNb = 1;
        }

        public static Counter Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new Counter();
                }
                return INSTANCE;
            }
        }

        /*
        public Counter(int size)
        {
            this.Size = size;
            this.Orders = new List<IOrder>();
            this.OrderNb = 1;
        }
        */

        public void AddOrder(IOrder newOrder)
        {

        }

        public void OrderPrepared(int OrderNum)
        {
            
        }
    }
}