using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Shared{
    /// <summary>
    /// Stores a quantity of a given utensil
    /// the quantity is stored in the database
    /// </summary>
    public class Drawer
    {
        //Primary key, the utensil
        [Key]
        public UtensilType UtensilType { get; set; }
        //The quantity the restaurant possesses
        //custom setter used to set the semaphore when the object is instanciated by EF
        //EF uses a parameterless constructor and sets the values of the public props with database data
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