using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Shared{
    public class Drawer
    {
        [Key]
        public UtensilType UtensilType { get; set; }
        public int Quantity {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                available = new Semaphore(0, value);
            }
        }
        private int quantity { get; set; }
        private Semaphore available;

        public Drawer(UtensilType utensil, int quantity)
        {
            UtensilType = utensil;
            Quantity = quantity;
        }

        public Drawer() { }
/*
        public Utensil getUtensil()
        {
            available.WaitOne();
            return new Utensil(UtensilType);
        }
*/

    }
}