using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order : IOrder
    {

        public int OrderNum { get; set; }
        public List<Dish> Dishes { get; set; }
        public ITable Table { get; set; }
        private List<IObserver<IOrder>> Observers = new List<IObserver<IOrder>>();


        public Order(List<Dish> dishes, ITable table)
        {
            this.Dishes = dishes;
            this.Table = table;
        }
    }
}
